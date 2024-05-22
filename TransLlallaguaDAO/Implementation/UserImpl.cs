using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TransLlallaguaDAO.Interfaces;
using TransLlallaguaDAO.Models;

namespace TransLlallaguaDAO.Implementation
{
    public class UserImpl : BaseImpl, IUser
    {
        public int Delete(UserR user)
        {
            query = @"UPDATE UserR SET status=0, lastUpdate=CURRENT_TIMESTAMP, userId=@userId
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userId", user.UserId);
            command.Parameters.AddWithValue("@id", user.Id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Insert(UserR user)
        {
            query = @"INSERT INTO UserR (names,surname,email,adress,gender,phone,username,password,role,userId,statusLogin)
                      VALUES (@names,@surname,@email,@adress,@gender,@phone,@username,HASHBYTES('MD5',@password),@role,@userId,0)";
            SqlCommand cmd = CreateBasicCommand(query);
            if (user.SecondSurname != "")
            {
                query = @"INSERT INTO UserR (names,surname,secondSurname,email,adress,gender,phone,username,password,role,userId,statusLogin)
                      VALUES (@names,@surname,@secondSurname,@email,@adress,@gender,@phone,@username,HASHBYTES('MD5',@password),@role,@userId,0)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@secondSurname", user.SecondSurname);
            }
            cmd.Parameters.AddWithValue("@names", user.Name);
            cmd.Parameters.AddWithValue("@surname", user.Surname);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@adress", user.Adress);
            cmd.Parameters.AddWithValue("@gender", user.Gender);
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Password).SqlDbType=SqlDbType.VarChar;
            cmd.Parameters.AddWithValue("@role", user.Role);
            cmd.Parameters.AddWithValue("@userId", user.UserId);
            try
            {
                return ExecuteBasicCommand(cmd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable Select()
        {
            query = @"SELECT id,names AS Nombres,surname AS 'Apellido Paterno',secondSurname AS 'Apellido Materno',email AS 'Correo electrónico',
	                  adress AS 'Dirección',gender AS 'Género',phone AS Celular,username AS 'Nombre de usuario',role AS Rol
                      FROM UserR
                      WHERE status=1
                      ORDER BY 2";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(UserR user)
        {
            query = @"UPDATE UserR SET names=@names, surname=@surname,
                                       email=@email,adress=@adress,gender=@gender,phone=@phone,username=@username,
                                       role=@role,
			                           lastUpdate=CURRENT_TIMESTAMP, userId=@userId
                      WHERE id=@id";
            SqlCommand cmd = CreateBasicCommand(query);
            if (user.SecondSurname != "")
            {
                query = @"UPDATE UserR SET names=@names, surname=@surname, secondSurname=@secondSurname,
                                       email=@email,adress=@adress,gender=@gender,phone=@phone,username=@username,
                                       role=@role,
			                           lastUpdate=CURRENT_TIMESTAMP, userId=@userId
                      WHERE id=@id";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@secondSurname", user.SecondSurname);
            }
            cmd.Parameters.AddWithValue("@names", user.Name);
            cmd.Parameters.AddWithValue("@surname", user.Surname);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@adress", user.Adress);
            cmd.Parameters.AddWithValue("@gender", user.Gender);
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@role", user.Role);
            cmd.Parameters.AddWithValue("@userId", user.UserId);
            cmd.Parameters.AddWithValue("@id", user.Id);
            try
            {
                return ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Login(string username,string password)
        {
            query = @"SELECT id,username,[role],statusLogin
                      FROM UserR
                      WHERE [status]=1 AND username=@username AND [password]=HASHBYTES('MD5',@password)";
            SqlCommand cmd = CreateBasicCommand(query);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password",password).SqlDbType=SqlDbType.VarChar;
            try
            {
                return ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        
        public bool ExistsUsername(string username)
        {
            query = "SELECT username FROM UserR WHERE username=@username";
            SqlCommand cmd = CreateBasicCommand(query);
            cmd.Parameters.AddWithValue("@username", username);
            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        public bool ExistsUsernameUpdate(string username,int id)
        {
            query = "SELECT username FROM UserR WHERE username=@username AND id<>@id";
            SqlCommand cmd = CreateBasicCommand(query);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public string CreateUsername(string surname,string names,int i)
        {
            string username="";
            string truncatedSurname = surname.Length > 9 ? surname.Substring(0, 9) : surname;
            if (i>0)
                username= $"{truncatedSurname.ToLower()}{names.Substring(0, 2).ToLower()}{i}";
            else
                username = $"{truncatedSurname.ToLower()}{names.Substring(0, 2).ToLower()}";

            if (!ExistsUsername(username))
                return username;
            else
                return CreateUsername(surname, names, i+1);
        }

        public string CreatePassword()
        {
            string[] abecedario = {"a","b","c","d","e","f","g","h","i","j","k","l","m",
                                   "n","o","p","q","r","s","t","u","v","w","x","y","z"};
            char[] simbolos = { '!', '#','*' };
            Random randomico = new Random();
            int randon = 0;
            string contrasenia = "";
            for (int i = 0; i < 9; i++)
            {
                randon = randomico.Next(1, 4);
                if (randon == 1)
                {
                    randon = randomico.Next(0, 26);
                    contrasenia += abecedario[randon];
                }
                else if (randon == 2)
                {
                    randon = randomico.Next(0, 26);
                    contrasenia += abecedario[randon].ToUpper();
                }
                else if (randon == 3)
                {
                    randon = randomico.Next(0, 10);
                    contrasenia += randon;
                }
            }
            randon = randomico.Next(0, 3);
            contrasenia += simbolos[randon];
            return contrasenia;
        }

        public UserR Get(int id)
        {
            UserR c = null;
            query = @" SELECT id,names,surname,secondSurname,email,adress,gender,phone,username,role,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP),userId
                    FROM UserR
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    c = new UserR(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), table.Rows[0][3].ToString(), table.Rows[0][4].ToString(),
                                  table.Rows[0][5].ToString(), char.Parse(table.Rows[0][6].ToString()), table.Rows[0][7].ToString(), table.Rows[0][8].ToString(), table.Rows[0][9].ToString(),
                                  byte.Parse(table.Rows[0][10].ToString()), DateTime.Parse(table.Rows[0][11].ToString()), DateTime.Parse(table.Rows[0][12].ToString()), int.Parse(table.Rows[0][13].ToString()));

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return c;
        }

        public bool EqualPassword(string password)
        {
            query = "SELECT password FROM UserR WHERE password=HASHBYTES('MD5',@password) AND id=@id";
            SqlCommand cmd = CreateBasicCommand(query);
            cmd.Parameters.AddWithValue("@password", password).SqlDbType=SqlDbType.VarChar;
            cmd.Parameters.AddWithValue("@id", SessionControl.UserID);
            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public bool SecurePassword(string password)
        {
            string patron = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[^\da-zA-Z]).{8,}$";
            return Regex.IsMatch(password, patron);
        }

        public int UpdatePassword(string password)
        {
            query = @"UPDATE UserR SET password=HASHBYTES('MD5',@password),statusLogin=1
                      WHERE id=@id";
            SqlCommand cmd = CreateBasicCommand(query);
            cmd.Parameters.AddWithValue("@password",password).SqlDbType=SqlDbType.VarChar;
            cmd.Parameters.AddWithValue("@id", SessionControl.UserID);
            try
            {
                return ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SendEmail(string to,string username,string password)
        {
            string from = "transllallagua@outlook.com";
            string displayName = "Trans Llallagua";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from,displayName);
                mail.To.Add(to);

                mail.Subject = "Credenciales de acceso";
                mail.Body = @"<div>
                                <h2>¡Bienvenido a nuestro equipo!</h2>
                                <p>Estas son tus credenciales de acceso al sistema:</p>
                                <p>Nombre de Usuario: "+username+@"</p>
                                <p>Contraseña: "+password+ @"</p>
                                <p>Se le recomienda no compartir estos datos.</p>
                              </div>";
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp-mail.outlook.com",587);
                client.Credentials = new NetworkCredential(from, "llallaguaLaGrande123.");
                client.EnableSsl = true;

                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectIDName()
        {
            query = @"SELECT id,CONCAT(surname,' ',names) AS Name
                      FROM UserR
                      WHERE status=1 AND role<>'CAJERO'
                      ORDER BY 2";
            SqlCommand cmd = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(cmd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
