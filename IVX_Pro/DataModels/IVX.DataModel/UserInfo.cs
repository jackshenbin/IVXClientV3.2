using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;

namespace IVX.DataModel
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Serializable]
    public class UserInfo : NotifyPropertyChangedModel
    {
        /// <summary>
        /// 所属组ID
        /// </summary>
        public UInt32 UserGroupID { get; set; }
		/// <summary>
		/// 用户句柄
		/// </summary>
		public UInt32 UserHandle { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public UInt32 UserID { get; set; }
        /// <summary>
        /// 用户角色类型，见vdacomm.h中E_VDA_USER_ROLE_TYPE定义
        /// </summary>
        public UInt32 UserRoleType { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
		/// <summary>
		/// 用户权限
		/// </summary>
		public UInt32 RightMask { get; set; }
		/// <summary>
		/// 用户的备注
		/// </summary>
		public string other { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNickName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 用户创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 用户信息最后一次修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        public UserInfo()
        { }

        public UserInfo Clone()
        {
            UserInfo newUser = new UserInfo()
            {
				UserGroupID = this.UserGroupID,
				UserHandle = this.UserHandle,
                UserID = this.UserID,
                UserRoleType = this.UserRoleType,
                UserName = this.UserName,
				RightMask = this.RightMask,
                UserNickName = this.UserNickName,
                UserPwd = this.UserPwd,
                CreateTime = this.CreateTime,
                UpdateTime = this.UpdateTime,
				other = this.other,
            };
            return newUser;
        }

    };



    #region UserRoleTypeInfo

    public class UserRoleTypeInfo
    {
        public E_VDA_USER_ROLE_TYPE Type { get; set; }

        public uint NType
        {
            get
            {
                return (uint)Type;
            }
        }

        public string Name { get; set; }

        public UserRoleTypeInfo(E_VDA_USER_ROLE_TYPE type, string name)
        {
            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    #endregion


}
