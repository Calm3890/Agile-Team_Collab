using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile_Team_Collab
{
    public class AddDao_2_
    {
        List<Add> barang = null;

        public AddDao_2_()
        {
            barang = new List<Add>();
        }
        public int simpan(string code, string name, int price, decimal tax)
        {
            int done = 0;
            if(price < 0)
            {
                throw new ArgumentException("Harga tidak boleh lebih kecil dari 0");
            }
            else if (tax > 100)
            {
                throw new ArgumentException("Tax tidak boleh melebihi 100");
            }
            else if (tax < 0)
            {
                throw new ArgumentException("Tax tidak boleh lebih kecil dari 0");
            }
            else if (code.Trim() == "")
            {
                throw new ArgumentException("Code tidak boleh kosong");
            }
            else if (name.Trim() == "")
            {
                throw new ArgumentException("Nama tidak boleh kosong");
            }
            else if (price == 0)
            {
                throw new ArgumentException("Price tidak boleh sama dengan 0");
            }
            try
            {
                barang.Add(new Add { Code = code, Name = name, Price = price});
                done = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return done;
        }

        public int Update(string code, string name, int price , decimal tax)
        {
            int done = 0;
            if (price < 0)
            {
                throw new ArgumentException("Harga tidak boleh lebih kecil dari 0");
            }
            else if (tax > 100)
            {
                throw new ArgumentException("Tax tidak boleh melebihi 100");
            }
            else if (tax < 0)
            {
                throw new ArgumentException("Tax tidak boleh lebih kecil dari 0");
            }
            else if (code.Trim() == "")
            {
                throw new ArgumentException("Code tidak boleh kosong");
            }
            else if (name.Trim() == "")
            {
                throw new ArgumentException("Nama tidak boleh kosong");
            }
            else if (price == 0)
            {
                throw new ArgumentException("Price tidak boleh sama dengan 0");
            }
            try
            {
                foreach (var item in barang)
                {
                    if(item.Code == code)
                    {
                        item.Name = name;
                        item.Price = price;
                        break;
                    }
                }
                done = 1;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return done;
        }

        public int Delete(string code)
        {
            int success = 0;
            if (code.Trim() == "")
            {
                throw new ArgumentException("Kode tak boleh kosong");
            }
            try
            {

                barang.Remove(barang.Find(i => i.Code == code));

                success = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }

        public Add GetCode(string code)
        {
            if (code.Trim() == "")
            {
                throw new ArgumentException("Kode tak boleh kosong");
            }
            Add result = null;
            try
            {
                foreach (var item in barang)
                {
                    if (item.Code == code)
                    {
                        result = item;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
