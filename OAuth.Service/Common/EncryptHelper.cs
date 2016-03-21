using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.Service.Common
{
    /// <summary>
    /// 加密 解密服务
    /// </summary>
    public abstract class EncryptHelper
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string Encrypt(string inputString)
        {
            string strEncryptConn = "";
            try
            {
                AESEDSVcrypts.AES_Encrypt(inputString, out strEncryptConn);
            }
            catch
            {
                strEncryptConn = "API出错了";
            }
            return strEncryptConn;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string Decrypt(string inputString)
        {
            string strEncryptConn = "";
            try
            {
                if (!AESEDSVcrypts.AES_Decrypt(inputString, out strEncryptConn))
                {
                    strEncryptConn = "";
                }
            }
            catch
            {
                strEncryptConn = "API出错了";
            }
            return strEncryptConn;
        }



        /// <summary>
        /// DES 加密(数据加密标准，速度较快，适用于加密大量数据的场合)
        /// </summary>
        /// <param name="encryptString">待加密的密文</param>
        /// <param name="encryptKey">加密的密钥</param>
        /// <returns>returns</returns>
        public static string DESEncrypt(string encryptString, string encryptKey)
        {
            if (string.IsNullOrEmpty(encryptString)) { throw (new Exception("密文不得为空")); }
            if (string.IsNullOrEmpty(encryptKey)) { throw (new Exception("密钥不得为空")); }
            if (encryptKey.Length != 8) { throw (new Exception("密钥必须为8位")); }

            byte[] m_btIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            string m_strEncrypt = "";

            DESCryptoServiceProvider m_DESProvider = new DESCryptoServiceProvider();

            try
            {
                byte[] m_btEncryptString = Encoding.Default.GetBytes(encryptString);
                MemoryStream m_stream = new MemoryStream();
                CryptoStream m_cstream = new CryptoStream(m_stream, m_DESProvider.CreateEncryptor(Encoding.Default.GetBytes(encryptKey), m_btIV), CryptoStreamMode.Write);

                m_cstream.Write(m_btEncryptString, 0, m_btEncryptString.Length);
                m_cstream.FlushFinalBlock();
                m_strEncrypt = Convert.ToBase64String(m_stream.ToArray());
                m_stream.Close();
                m_stream.Dispose();
                m_cstream.Close();
                m_cstream.Dispose();
            }

            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { m_DESProvider.Clear(); }

            return m_strEncrypt;
        }

        /// <summary>
        /// DES 解密(数据加密标准，速度较快，适用于加密大量数据的场合)
        /// </summary>
        /// <param name="decryptString">待解密的密文</param>
        /// <param name="decryptKey">解密的密钥</param>
        /// <returns>returns</returns>
        public static string DESDecrypt(string decryptString, string decryptKey)
        {
            if (string.IsNullOrEmpty(decryptString)) { throw (new Exception("密文不得为空")); }
            if (string.IsNullOrEmpty(decryptKey)) { throw (new Exception("密钥不得为空")); }
            if (decryptKey.Length != 8) { throw (new Exception("密钥必须为8位")); }
        
            byte[] m_btIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            string m_strDecrypt = "";

            DESCryptoServiceProvider m_DESProvider = new DESCryptoServiceProvider();

            try
            {
                byte[] m_btDecryptString = Convert.FromBase64String(decryptString);
                MemoryStream m_stream = new MemoryStream();
                CryptoStream m_cstream = new CryptoStream(m_stream, m_DESProvider.CreateDecryptor(Encoding.Default.GetBytes(decryptKey), m_btIV), CryptoStreamMode.Write);

                m_cstream.Write(m_btDecryptString, 0, m_btDecryptString.Length);
                m_cstream.FlushFinalBlock();
                m_strDecrypt = Encoding.Default.GetString(m_stream.ToArray());
                m_stream.Close();
                m_stream.Dispose();
                m_cstream.Close();
                m_cstream.Dispose();
            }
            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { m_DESProvider.Clear(); }

            return m_strDecrypt;
        }
    }
}
