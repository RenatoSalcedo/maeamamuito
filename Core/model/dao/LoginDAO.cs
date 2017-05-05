using System.Text;
using oficial.Core.util;

namespace oficial.Core.model.dao
{
    public class LoginDAO
    {
        BDConnect bdConnect = new BDConnect();

        public int verifySession(string userName, string userPass)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("@user = " + userName.ToString());
            sb.Append("@pass = " + userPass.ToString());

            return verifySession(sb);
        }

        private int verifySession(StringBuilder filtro)
        {
            StringBuilder sbComando = new StringBuilder();

            sbComando.AppendLine("Exec PR_VERIFY_SESSION ");
            sbComando.AppendLine(filtro.ToString());

            DataSet ds = new DataSet();
            ds = bd.retornaDadosSQL(sbComando.ToString());

            int session = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {        
                session = int.Parse(dr["SESSION_OPEN"].ToString());
            }

            return session;
        }

        public User login(string userName, string userPass)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("@user = " + userName.ToString());    
            sb.Append("@pass = " + userPass.ToString());

            return login(sb);
        }

        private User login(StringBuilder filtro)
        {
            StringBuilder sbComando = new StringBuilder();

            sbComando.AppendLine("Exec PR_LOGIN ");
            sbComando.AppendLine(filtro.ToString());

            DataSet ds = new DataSet();
            ds = bd.retornaDadosSQL(sbComando.ToString());

            User loggedUser = new User();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {        
                loggedUser.UserID = int.Parse(dr["USER_ID"].ToString());
                loggedUser.UserName = dr["USER_NAME"].ToString();
                loggedUser.UserPass = dr["USER_PASS"].ToString();
            }

            return loggedUser;
        }
    }
}