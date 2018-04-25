using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using Common.Logic;
using Common.API;

namespace O2JAM.O2JAMDataInfo
{
	/// <summary>
	/// CharacterInfo ��ժҪ˵����
	/// </summary>
	public class CharacterInfo
	{
		public CharacterInfo()
		{
			//
			// TODO: �ڴ˴����ӹ��캯���߼�
			//
		}
		#region �鿴�������
		/// <summary>
		/// �鿴�������
		/// </summary>
		/// <param name="serverIP"></param>
		/// <param name="account"></param>
		/// <returns></returns>
		public static DataSet characterInfo_Query(string serverIP,string account,string userNick)
		{
			DataSet result = null;
			SqlParameter[] paramCode;
			try
			{
				paramCode = new SqlParameter[3]{
												   new SqlParameter("@O2JAM_serverip",SqlDbType.VarChar,20),
												   new SqlParameter("@O2JAM_UserID",SqlDbType.VarChar,20),
												   new SqlParameter("@O2JAM_NickName",SqlDbType.VarChar,20)};
				paramCode[0].Value = serverIP;
				paramCode[1].Value = account;
				paramCode[2].Value = userNick;
				result = SqlHelper.ExecSPDataSet("O2JAM_Charinfo_Query",paramCode);
			}
			catch(SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return result;
		}
		#endregion
		#region �޸������������
		/// <summary>
		/// �޸��������
		/// </summary>
		/// <param name="userByID">����ԱID</param>
		/// <param name="serverIP">������IP</param>
		/// <param name="account">�ʺ�</param>
		/// <param name="level">�ȼ�</param>
		/// <param name="experience">����ֵ</param>
		/// <param name="battle">�ܾ���</param>
		/// <param name="win">ʤ��</param>
		/// <param name="draw">ƽ��</param>
		/// <param name="lose">����</param>
		/// <param name="MCash">M��</param>
		/// <param name="GCash">G��</param>
		/// <returns></returns>
		public static int characterInfo_Update(int userByID,string serverIP,string account,int userIndexID,int level,int experience,int battle,int win,int draw,int lose,int GCash)
		{
			int result = -1;
			SqlParameter[] paramCode;
			try
			{
				paramCode = new SqlParameter[12]{
													new SqlParameter("@Gm_UserID",SqlDbType.Int),
													new SqlParameter("@O2JAM_ServerIP",SqlDbType.VarChar,30),
													new SqlParameter("@O2JAM_UserID",SqlDbType.VarChar,20),
													new SqlParameter("@O2JAM_Level",SqlDbType.Int),
													new SqlParameter("@O2JAM_Experience",SqlDbType.Int),
													new SqlParameter("@O2JAM_Total",SqlDbType.Int),
													new SqlParameter("@O2JAM_Win",SqlDbType.Int),
													new SqlParameter("@O2JAM_Draw",SqlDbType.Int),
													new SqlParameter("@O2JAM_Lose",SqlDbType.Int),
													new SqlParameter("@O2JAM_UserIndexID",SqlDbType.Int),
													new SqlParameter("@O2JAM_GCash",SqlDbType.Int),
													new SqlParameter("@result",SqlDbType.Int)};
				paramCode[0].Value=userByID;
				paramCode[1].Value=serverIP;
				paramCode[2].Value=account;
				paramCode[3].Value=level;
				paramCode[4].Value=experience;
				paramCode[5].Value=battle;
				paramCode[6].Value=win;
				paramCode[7].Value=draw;
				paramCode[8].Value=lose;
				paramCode[9].Value=userIndexID;
				paramCode[10].Value=GCash;
				paramCode[11].Direction = ParameterDirection.ReturnValue;
				result = SqlHelper.ExecSPCommand("O2JAM_Charinfo_Update",paramCode);
			}
			catch(SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return result;

		}
		#endregion
	}
     
}