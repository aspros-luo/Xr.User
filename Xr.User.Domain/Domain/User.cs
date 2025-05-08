using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xr.User.Domain.Domain;

namespace Xr.User.Domain
{
    public class User : BasicEntity, IAggregateRoot
    {
        public long Id { get; protected set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; protected set; } = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; protected set; } = string.Empty;
        /// <summary>
        /// 密码盐
        /// </summary>
        public string PasswordSalt { get; protected set; } = DateTime.Now.Ticks.ToString();
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType Type { get; protected set; } = 0;
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; protected set; } = string.Empty;
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; protected set; } = string.Empty;
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNo { get; protected set; } = string.Empty;
        /// <summary>
        /// 是否实名认证
        /// </summary>
        public bool IsReal { get; protected set; } = false;
        /// <summary>
        /// 性别
        /// </summary>
        public SexType Sex { get; protected set; } = 0;
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Birthday { get; protected set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; protected set; } = string.Empty;
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; protected set; } = string.Empty;

        public virtual ICollection<UserFollow> UserFollows { get; protected set; } = [];
        public virtual UserServer UserServer { get; protected set; } = new UserServer();
        public virtual ICollection<UserOauth> UserOauths { get; protected set; } = [];

        public User()
        {

        }

        public User(string userName, string password, UserType type)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)) throw new ArgumentException("用户名或密码不能为空");
            UserName = userName;
            Password = Md5Password(password);
            NickName = userName;
            Type = type;
            if (type == UserType.Photographer || type == UserType.Makeuper) UserServer = new UserServer();
        }

        public User(string phone, UserType userType)
        {
            if (string.IsNullOrEmpty(phone)) throw new ArgumentException("手机号不能为空");
            Phone = phone;
            UserName = phone;
            NickName = phone;
            Type = userType;
            if (userType == UserType.Photographer || userType == UserType.Makeuper) UserServer = new UserServer();
        }

        public bool CheckPhoneExist()
        {
            return !string.IsNullOrEmpty(Phone);
        }

        /// <summary>
        /// 修改用户基础信息
        /// </summary>
        /// <param name="nickName"></param>
        /// <param name="sex"></param>
        /// <param name="birthday"></param>
        /// <param name="avatar"></param>
        /// <param name="phone"></param>
        public void ModifyInfo(string nickName, SexType? sex, DateTime? birthday, string avatar)
        {
            if (!string.IsNullOrEmpty(nickName)) NickName = nickName;
            if (sex.HasValue) Sex = sex.Value;
            if (birthday.HasValue) Birthday = birthday.Value;
            if (!string.IsNullOrEmpty(avatar)) Avatar = avatar;
        }

        /// <summary>
        /// 用户实名认证
        /// </summary>
        /// <param name="realName"></param>
        /// <param name="idNo"></param>
        /// <exception cref="ArgumentException"></exception>
        public void VerifyUserReal(string realName, string idNo)
        {
            if (string.IsNullOrEmpty(realName) || string.IsNullOrEmpty(idNo)) throw new ArgumentException("真实姓名或身份证号不能为空");
            RealName = realName;
            IdNo = idNo;
            IsReal = true;
        }

        /// <summary>
        /// 关注
        /// </summary>
        /// <param name="valueId"></param>
        /// <param name="type"></param>
        public void Follow(long valueId, FollowType type)
        {
            if (UserFollows != null)
            {
                var userFollow = UserFollows.FirstOrDefault(x => x.ValueId == valueId && x.Type == type);
                if (userFollow == null)
                {
                    userFollow = new UserFollow(Id, type, valueId);
                    UserFollows.Add(userFollow);
                }
                userFollow.Follow();
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(username)) throw new Exception("用户名或密码不能为空");
            return username.Equals(UserName) && password.Equals(Md5Password(Password));
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <exception cref="ArgumentException"></exception>
        public void UpdatePassword(string oldPassword, string newPassword)
        {
            var md5OldPassword = Md5Password(oldPassword);
            if (!md5OldPassword.Equals(Password))
            {
                throw new ArgumentException("原密码不正确");
            }

            var md5Password = Md5Password(newPassword);
            //            if (this.LoginPwd == md5Password)
            //            {
            //                throw new ArgumentException("新密码和旧密码不能一样");
            //            }
            Password = md5Password;
        }

        /// <summary>
        /// 充值密码
        /// </summary>
        /// <param name="password"></param>
        public void ResetPassword(string password)
        {
            var md5Password = Md5Password(password);
            //            if (this.LoginPwd == md5Password)
            //            {
            //                throw new ArgumentException("新密码和旧密码不能一样");
            //            }
            Password = md5Password;
        }

        private string Md5Password(string password)
        {
            return SignUtil.Md5Sign(password + SignUtil.Md5Sign(PasswordSalt));
        }


    }
}
