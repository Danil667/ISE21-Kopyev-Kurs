using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Implements
{
	public class SaveData
	{
		public static void Save(List<User> users)
		{
            var strJson = JsonConvert.SerializeObject(users);
            using (var context = new Database())
            {
                Models.Data elem = context.Datas.FirstOrDefault();
                if (string.IsNullOrEmpty(strJson))
                {
                    throw new Exception("Нет данных");
                }
                else
                {
                    elem = new Models.Data();
                    context.Datas.Add(elem);
                }
                elem.text = strJson;
                context.SaveChanges();
            }
        }
        public List<User> Read()
        {
            using (var context = new Database())
            {
                var jsonStr = context.Datas.FirstOrDefault().text;
                return JsonConvert.DeserializeObject<List<User>>(jsonStr);
            }
        }
    }
}
