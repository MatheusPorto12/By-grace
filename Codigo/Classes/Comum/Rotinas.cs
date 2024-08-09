using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace ByGrace.Classes.Comum
{
    public class Rotinas
    {

        public static SelectList RetornarListaEnum(Type enumType, int itemSel = 0, bool ordenar = true, int[] somenteValores = null, int[] excetoValores = null, bool exibirTextoTodos = false)
        {
            SelectListItem selectListItem = null;
            List<SelectListItem> list = new List<SelectListItem>();
            if (exibirTextoTodos && !ordenar)
            {
                SelectListItem item = new SelectListItem
                {
                    Value = "0",
                    Text = "Todos",
                    Selected = (itemSel == 0)
                };
                list.Add(item);
            }

            foreach (object value in Enum.GetValues(enumType))
            {
                if ((somenteValores == null || somenteValores.Contains((int)value)) && !(excetoValores?.Contains((int)value) ?? false))
                {
                    FieldInfo field = enumType.GetField(value.ToString());
                    object obj = field.GetCustomAttributes(typeof(DescriptionAttribute), inherit: true).FirstOrDefault();
                    string text = ((obj == null) ? value.ToString() : ((DescriptionAttribute)obj).Description);
                    if ((int)value == itemSel)
                    {
                        selectListItem = new SelectListItem
                        {
                            Value = ((int)value).ToString(),
                            Text = text,
                            Selected = true
                        };
                    }
                    else
                    {
                        SelectListItem item2 = new SelectListItem
                        {
                            Value = ((int)value).ToString(),
                            Text = text,
                            Selected = ((int)value == itemSel)
                        };
                        list.Add(item2);
                    }
                }
            }

            if (!ordenar)
            {
                return new SelectList(list, "Value", "Text", itemSel);
            }

            IEnumerable<SelectListItem> enumerable = list.OrderBy((SelectListItem x) => x.Text);
            if (selectListItem == null)
            {
                return new SelectList(enumerable, "Value", "Text", itemSel);
            }

            List<SelectListItem> list2 = new List<SelectListItem>();
            list2.Add(selectListItem);
            foreach (SelectListItem item3 in enumerable)
            {
                list2.Add(item3);
            }

            return new SelectList(list2, "Value", "Text", itemSel);
        }

        public static string RetornarDescricaoAmigavelEnum(Enum tipo)
        {
            if (tipo == null)
            {
                return "";
            }

            if (Convert.ToInt32(tipo) == 0)
            {
                bool flag = true;
            }

            try
            {
                FieldInfo field = tipo.GetType().GetField(tipo.ToString());
                DescriptionAttribute[] array = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
                if (array.Length != 0)
                {
                    return array[0].Description;
                }

                return tipo.ToString();
            }
            catch (Exception)
            {
                return tipo.ToString();
            }
        }

        public static string FormatarValor(double valor, string formato = "#,##0.00")
        {
            return valor.ToString(formato);
        }
    }
}
