﻿using System.Security.Cryptography;
using System.Text;

namespace Connect_agenda_api.Encryption
{
    public static class Encrypting
    {
        public static string Encrypt(this string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
