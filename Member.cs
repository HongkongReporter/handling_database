using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Member
/// </summary>
namespace Insus.NET
{
    public class Member
    {
        private string _UserName;
        private string _Email;
        private string _Position;
        private string _PhoneN;
        private string _Age;
        private string _Sex;
        private int _picIndex;
        /*
         Featured vector is of string type.
         */
        int _pic;
        /*
         * for the parts where the identification is 
         * involved, this would be neccessary.
         */
        private bool _IsUser;
        
        public int picIndex {
            get { return _picIndex; }
            set { _picIndex = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public string Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        public string PhoneN
        {
            get { return _PhoneN; }
            set { _PhoneN = value; }
        }
        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        public int Face
        {
            get { return _pic; }
            set { _pic = value; }
        }

        /*
         * Only need regitered user as is.
         * leave this interface for visitors.
         */
        public bool IsUser
        {
            get { return _IsUser; }
            set { _IsUser = value; }
        }

        BusinessBase objBusinessBase = new BusinessBase();
        
        public Member()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetAll()
        {
            return objBusinessBase.GetDataToDataSet("usp_Member_GetAll").Tables[0];
        }
        
        /*
         * communicate w/h SQL
         */
        
        public void Insert()
        {
            Parameter[] parameter = { 
                                        new Parameter ("@UserName",SqlDbType.NVarChar,-1,_UserName),
                                        new Parameter ("@Email",SqlDbType.NVarChar,-1,_Email),
                                        new Parameter ("@PhoneN",SqlDbType.NVarChar,-1,_PhoneN),
                                        new Parameter ("@Age",SqlDbType.NVarChar,-1,_Age),
                                        new Parameter ("@Face",SqlDbType.NVarChar,-1,_pic),
                                        new Parameter ("@Sex",SqlDbType.NVarChar,-1,_Sex),
                                        new Parameter ("@Position",SqlDbType.NVarChar,-1,_Position),
                                        new Parameter ("@picIndex",SqlDbType.Int,-1,_Position)

                                    };
            objBusinessBase.ExecuteProcedure("usp_Member_Insert", parameter);
        }

        /*
         * Need update
         */

        public void Update()
        { 
             Parameter[] parameter = { 
                                        new Parameter ("@UserName",SqlDbType.NVarChar,-1,_UserName),
                                        new Parameter ("@Email",SqlDbType.NVarChar,-1,_Email),
                                        new Parameter ("@PhoneN",SqlDbType.NVarChar,-1,_PhoneN),
                                        new Parameter ("@Age",SqlDbType.NVarChar,-1,_Age),
                                        new Parameter ("@Face",SqlDbType.NVarChar,-1,_pic),
                                        new Parameter ("@Sex",SqlDbType.NVarChar,-1,_Sex),
                                        new Parameter ("@Position",SqlDbType.NVarChar,-1,_Position),
                                        new Parameter ("@picIndex",SqlDbType.Int,-1,_Position)
                                    };
            objBusinessBase.ExecuteProcedure("usp_Member_Update", parameter);
        }
    }
}
