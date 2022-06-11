/* Copyright © 2021 ThinkAI (). All Rights Reserved.
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * 
 * Author: Atul Badgujar <atul.badgujar2@gmail.com>
 * Date: 09 May 2021
 * 
 * Contributor/s: 
 * Last Updated On: 09 May 2021
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace TurrantKar.Common
{
    public static class DataTableConverter
    {
        public static DataTable ConvertToDataTableList<T>(this IEnumerable<T> dataList) where T : class
        {
            DataTable convertedTable = new DataTable();
            PropertyInfo[] propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int j = 0;
            foreach (PropertyInfo prop in propertyInfo)
            {
                if (j >= 25 && j <= 29)
                {
                    convertedTable.Columns.Add(prop.Name).DataType = System.Type.GetType("System.DateTime");
                }
                else
                {
                    convertedTable.Columns.Add(prop.Name);
                }
                j++;
                //convertedTable.Columns.Add(prop.Name);
            }
            foreach (T item in dataList)
            {
                var row = convertedTable.NewRow();
                var values = new object[propertyInfo.Length];

                int k = 0;
                for (int i = 0; i < propertyInfo.Length; i++)
                {
                    if (k >= 25 && k <= 29)
                    {
                        var test = propertyInfo[i].GetValue(item, null);
                        if (test == null)
                            row[i] = DBNull.Value;
                        else
                            row[i] = propertyInfo[i].GetValue(item, null);
                    }

                    else
                    {
                        var test = propertyInfo[i].GetValue(item, null);
                        row[i] = propertyInfo[i].GetValue(item, null);
                    }
                    k++;
                }
                convertedTable.Rows.Add(row);
            }
            return convertedTable;
        }

        public static DataTable OldConvertToDataTable<T>(this T dataList) where T : class
        {
            DataTable convertedTable = new DataTable();
            PropertyInfo[] propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int j = 0;
            int totalProperty = 31;
            int remainingProperty; 
            foreach (PropertyInfo prop in propertyInfo)
            {
                convertedTable.Columns.Add(prop.Name);
                j++;
            }
            remainingProperty = totalProperty - j;
            //Rest Column Value Pass null 
            for (int i = 0; i < remainingProperty; i++)
            {                
                convertedTable.Columns.Add(i.ToString());
            }
            var row = convertedTable.NewRow();
                var values = new object[propertyInfo.Length];
                for (int i = 0; i < propertyInfo.Length; i++)
                {
                    var test = propertyInfo[i].GetValue(dataList, null);
                    row[i] = propertyInfo[i].GetValue(dataList, null);
                }
                convertedTable.Rows.Add(row);
            
            return convertedTable;
        }

        public static DataTable ConvertToDataTable<T>(this T dataList) where T : class
        {
            DataTable convertedTable = new DataTable();
            PropertyInfo[] propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int j = 0;
            foreach (PropertyInfo prop in propertyInfo)
            {
                if (j >= 25 && j <= 29)
                {
                    convertedTable.Columns.Add(prop.Name).DataType = System.Type.GetType("System.DateTime");
                }
                else
                {
                    convertedTable.Columns.Add(prop.Name);
                }
                j++;
                //convertedTable.Columns.Add(prop.Name);
            }
            var row = convertedTable.NewRow();
            var values = new object[propertyInfo.Length];

            int k = 0;
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                if (k >= 25 && k <= 29)
                {
                    var test = propertyInfo[i].GetValue(dataList, null);
                    if(test == null)
                    row[i] = DBNull.Value;
                    else
                    row[i] = propertyInfo[i].GetValue(dataList, null);
                }
                
                else
                {
                    var test = propertyInfo[i].GetValue(dataList, null);
                    row[i] = propertyInfo[i].GetValue(dataList, null);
                }
                k++;
            }
            convertedTable.Rows.Add(row);

            return convertedTable;
        }
    }
}
