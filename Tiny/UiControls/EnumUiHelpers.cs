﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tiny.UiControls
{
    public class EnumerationManager
    {
        public static Array GetValues(Type enumeration)
        {
            var wArray = Enum.GetValues(enumeration);
            var wFinalArray = new ArrayList();
            foreach (Enum wValue in wArray)
            {
                var fi = enumeration.GetField(wValue.ToString());
                if (null != fi)
                {
                    var wBrowsableAttributes = fi.GetCustomAttributes(typeof(BrowsableAttribute), true) as BrowsableAttribute[];
                    if (wBrowsableAttributes.Length > 0)
                    {
                        //  If the Browsable attribute is false
                        if (wBrowsableAttributes[0].Browsable == false)
                        {
                            // Do not add the enumeration to the list.
                            continue;
                        }
                    }

                    var wDescriptions = fi.GetCustomAttributes(typeof(DescriptionAttribute), true) as DescriptionAttribute[];
                    if (wDescriptions.Length > 0)
                    {
                        wFinalArray.Add(wDescriptions[0].Description);
                    }
                    else
                        wFinalArray.Add(wValue);
                }
            }

            return wFinalArray.ToArray();
        }
    }
}
