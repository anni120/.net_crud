using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace fullcrud.Models
{
    public class Registration
    {
        [Display(Name = "Enter Name")]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }


        [Display(Name = "Enter Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }


        [Display(Name = "Enter Mobile")]
        [Required(ErrorMessage = "Please Enter Mobile")]
        public string Mobile { get; set; }


        [Display(Name = "Enter DOB")]
        [Required(ErrorMessage = "Please Enter DOB")]
        public string DOB { get; set; }

        [Display(Name = "Enter Gender")]
        [Required(ErrorMessage = "Please Enter Gender")]
        public string Gender { get; set; }


        [Display(Name = "Enter Address")]
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }


        [Display(Name = "Enter Adhar Number")]
        [Required(ErrorMessage = "Please Enter Adhar_Number")]
        public string Adhar_Number { get; set;}



        [Display(Name = "Enter Pan Number")]
        [Required(ErrorMessage = "Please Enter Pan Number")]
        public string Pan_Number { get; set; }

        [Display(Name = "Choose Picture")]
        [Required(ErrorMessage = "Please Choose Picture")]
        public HttpPostedFileBase Pic { get; set; }
        public string file { get; set; }
       

        [Display(Name = "Enter Password")]
        [Required(ErrorMessage = "Please Enter Enter Password")]
        public string Password { get; set; }


        [Display(Name = "Enter Conform Password")]
        [Required(ErrorMessage = "Please Enter Conform Password ")]
        public string Conform_Password { get; set; }
        public string rdate { get; set; }
        public string id { get; set; }


        public string   Insert_Register()
        {
            if(Password==Conform_Password)
            {
           
            string query="insert into Registeration values ('"+Name+"','"+Email+"','"+Mobile+"','"+DOB+"','"+Gender+"','"+Adhar_Number+"','"+Pan_Number+"','"+Address+"','"+Pic.FileName+"','"+Password+"','"+DateTime.Now.ToString()+"')";
            DatabaseManager db=new DatabaseManager();
            if(db.insert_update_delete(query))
                return "Registration Done ";
            else
            return "Error";
            }
            else
            {
                return "Plase check Password ";
            }
            
        }

        public static List<Registration> Select_Register()
        {
            List<Registration> lst = new List<Registration>();
            string query = "select * from Registeration";
            DatabaseManager db = new DatabaseManager();
            DataTable dt=db.display_all_record(query);
           if(dt.Rows.Count>0)
           {
               
               for(int i=0;i<dt.Rows.Count;i++)
               {
                   Registration R = new Registration();
                   R.id = Convert.ToString(dt.Rows[i]["id"]);
                   R.Name = Convert.ToString(dt.Rows[i]["name"]);
                   R.Email = Convert.ToString(dt.Rows[i]["email"]);
                   R.Mobile = Convert.ToString(dt.Rows[i]["mobile"]);
                   R.DOB = Convert.ToString(dt.Rows[i]["DOB"]);
                   R.Gender = Convert.ToString(dt.Rows[i]["gender"]);
                   R.Adhar_Number = Convert.ToString(dt.Rows[i]["adhar"]);
                   R.Pan_Number = Convert.ToString(dt.Rows[i]["pan"]);
                   R.Address = Convert.ToString(dt.Rows[i]["address"]);
                   R.file = Convert.ToString(dt.Rows[i]["picture"]);
                   R.Password = Convert.ToString(dt.Rows[i]["password"]);
                   R.rdate = Convert.ToString(dt.Rows[i]["rdate"]);
                   lst.Add(R);
                   

               }
           
           }

           return lst;
        }

        public static Registration Select_Update_Register(string up)
        {
            Registration R = new Registration();
           // List<Registration>lst=new List<Registration>();
            string query="select * from Registeration where email='"+up+"'";
            DatabaseManager db = new DatabaseManager();
            DataTable dt = db.display_all_record(query);
            //DataTable dt = DatabaseManager.display_all_record(query);
            if(dt.Rows.Count>0)
            {
                   R.Name= Convert.ToString(dt.Rows[0]["name"]);
                   R.Email = Convert.ToString(dt.Rows[0]["email"]);
                   R.Mobile = Convert.ToString(dt.Rows[0]["mobile"]);
                   R.DOB = Convert.ToString(dt.Rows[0]["DOB"]);
                   //R.Gender = Convert.ToString(dt.Rows[0]["gender"]);
                   R.Adhar_Number = Convert.ToString(dt.Rows[0]["adhar"]);
                   R.Pan_Number = Convert.ToString(dt.Rows[0]["pan"]);
                   R.Address = Convert.ToString(dt.Rows[0]["address"]);
                   R.Password = Convert.ToString(dt.Rows[0]["password"]);
                   R.file = Convert.ToString(dt.Rows[0]["picture"]);
                
                //lst.Add(R);
                
            }
            return R;
        }

        public string Update_Register()
        {
            string query = "update Registeration set name='" + Name + "', mobile='" + Mobile + "',DOB='" + DOB + "',adhar='" + Adhar_Number + "',pan='" + Pan_Number + "',address='" + Address + "',password='" + Password + "',picture='"+Pic+"'where email='" + Email + "'";
            DatabaseManager db = new DatabaseManager();
            if(db.insert_update_delete(query))
            {
                return "Update Successfully";
            }
            else
            {
                return "error";
            }
        }

        public string  Delete_Register(string del)
        {
            string query="delete from Registeration where email='"+del+"'";
            DatabaseManager db=new DatabaseManager();
            if(db.insert_update_delete(query))
            {
                return "Deleted";
            }
            else
            {
                return "error";
            }
        }
        

       
    }
}