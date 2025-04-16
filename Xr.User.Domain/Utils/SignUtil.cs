using System.Security.Cryptography;
using System.Text;

namespace Xr.User.Domain
{
    public static class SignUtil
    {
        public static string Md5Sign(this string str)
        {
            //将字符串编码为字节序列
            byte[] bt = Encoding.UTF8.GetBytes(str);
            //创建默认实现的实例
            //计算指定字节数组的哈希值。
            var md5bt = MD5.HashData(bt);
            //将byte数组转换为字符串
            StringBuilder builder = new();
            foreach (var item in md5bt)
            {
                builder.Append(item.ToString("X2"));
            }
            return builder.ToString();
        }
    }
}
