using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using KJEncryptionApi.Models;

namespace KJEncryptionApi.Service
{
    public class EncodeDecodeService
    {
        private readonly Dictionary<char, char> _keys;

        public EncodeDecodeService()
        {
            _keys = new Dictionary<char, char>();
            _keys.Add('a', '龠');
            _keys.Add('b', '龜');
            _keys.Add('c', '龍');
            _keys.Add('d', '齒');
            _keys.Add('e', '齊');
            _keys.Add('f', '鼻');
            _keys.Add('g', '鼠');
            _keys.Add('h', '鼓');
            _keys.Add('i', '鼎');
            _keys.Add('j', '黽');
            _keys.Add('k', '黹');
            _keys.Add('l', '黑');
            _keys.Add('m', '黍');
            _keys.Add('n', '米');
            _keys.Add('o', '麻');
            _keys.Add('p', '麥');
            _keys.Add('q', '鹿');
            _keys.Add('r', '瓜');
            _keys.Add('s', '鳥');
            _keys.Add('t', '魚');
            _keys.Add('u', '鬼');
            _keys.Add('v', '鬲');
            _keys.Add('w', '鬯');
            _keys.Add('x', '鬥');
            _keys.Add('y', '髟');
            _keys.Add('z', '高');
            _keys.Add(' ', '骨');
            _keys.Add('.', '大');
            _keys.Add(',', '田');
            _keys.Add(';', '山');
            _keys.Add(':', '自');
            _keys.Add('!', '殳');
            _keys.Add('?', '肉');
            _keys.Add('\"', '子');
            _keys.Add('\'', '女');
            _keys.Add('`', '又');
        }

        public string Encode(string text)
        {
            try
            {
                text = text.ToLower();

                var sb = new StringBuilder();

                foreach (var letter in text)
                {
                    sb.Append(_keys[letter]);
                }

                return sb.ToString();
            }
            catch (Exception)
            {
                return "Your text cannot be encoded!";
            }

        }

        public string Decode(string text)
        {
            try
            {
                var decoder = _keys.ToDictionary(q => q.Value, q => q.Key);

                text = text.ToLower();

                var sb = new StringBuilder();

                foreach (var letter in text)
                {
                    sb.Append(decoder[letter]);
                }

                return sb.ToString();
            }
            catch (Exception)
            {
                return "Your text cannot be decoded!";
            }
        }

    }
}