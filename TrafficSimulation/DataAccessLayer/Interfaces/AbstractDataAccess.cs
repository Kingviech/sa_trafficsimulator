﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace DataAccessLayer
{
    // generic Class implementing the basic CRUD and persistence handling for 
    // objects identified by an ID element of int Type.
    public abstract class AbstractDataAccess<T> : IDataAccess<T>
    {
        List<T> liste = new List<T>();
        private int uniqueId = 1;
        private string datafileprefix = "datafile_";
        private string datafileextension = ".txt";


        public int getuniqueId()
        {
            return uniqueId++;
        }
        public virtual void Init()
        {
            liste = new List<T>();
            uniqueId = 0;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual T Create(T objekt)
        {
            if (getObjectId(objekt) == 0)
                objekt = setObjectId(objekt, getuniqueId());
            Trace.TraceInformation("create(" + objekt.GetType().Name + ") Id=" + getObjectId(objekt));
            liste.Add(objekt);
            return objekt;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void Update(T objekt)
        {
            // Todo: cheap implenetation, expensive runtime.... 
            Trace.TraceInformation("update(" + objekt.GetType().Name + ")" + getObjectId(objekt));
            Delete(objekt);
            Create(objekt);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void Delete(T objekt)
        {
            int gefundenIndex = -1;
            int index = -1;

            int interestingId = getObjectId(objekt);

            Trace.TraceInformation("delete(" + objekt.GetType().Name + ")" + getObjectId(objekt));
            if (liste != null)
            {
                // Todo: so gehts wahrscheinlich performanter:
                // var matchingObjekt = liste.FirstOrDefault(T => liste.Id == interestingId));
                // wie in http://stackoverflow.com/questions/19280986/best-way-to-update-an-element-in-a-generic-list
                foreach (var currT in liste)
                {
                    index++;
                    int extractedId = getObjectId(currT);
                    if (extractedId == interestingId)
                    {
                        gefundenIndex = index;
                        break;
                    }
                }
            }
            if (gefundenIndex != -1)
                liste.RemoveAt(index);
        }

        public virtual T deserializefromString(string serialized)
        {
            return new JavaScriptSerializer().Deserialize<T>(serialized);
        }

        public string serialize2String(T objekt)
        {
            return new JavaScriptSerializer().Serialize(objekt);
        }

        public void LoadfromFile(string filename)
        {
            string line = "";
            try
            {
                // TODO: move to config/resources....
                string relPath = Directory.GetCurrentDirectory();
                relPath = "..\\..\\..\\DataAccessLayer\\";
                using (StreamReader readfile = new StreamReader(relPath + getfilenamePrefix() + filename + getfilenameExtension()))
                {
                    while ((line = readfile.ReadLine()) != null)
                    {
                        // Comments start with #, others will be deserialized
                        if (line.Substring(0, 1) != "#")
                        {
                            T readObjekt = new JavaScriptSerializer().Deserialize<T>(line);
                            uniqueId = Math.Max(uniqueId, getObjectId(readObjekt));
                            liste.Add(readObjekt);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Filelesen geht ned:" + filename + "(" + line + ")");
                Console.WriteLine(e.Message);
            }
        }

        public virtual void SavetoFile(string filename)
        {
            try
            {
                using (StreamWriter writefile = new StreamWriter(getfilenamePrefix() + filename + getfilenameExtension()))
                {
                    foreach (var objekt in liste)
                        writefile.WriteLine(serialize2String(objekt));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fileschreiben geht ned:" + filename);
                Console.WriteLine(e.Message);
            }
        }

        public virtual T ReadbyId(int Id)
        {
            foreach (T currT in liste)
            {
                int extractedId = getObjectId(currT);

                if (extractedId == Id)
                    return currT;
            }
            return default(T);
        }

        public virtual List<T> ReadAll()
        {
            return liste;
        }
        
        private int getObjectId(T objekt)
        {
            var propertyO = objekt.GetType().GetProperty("Id");
            int interestingId = (int)propertyO.GetValue(objekt, null);
            return interestingId;
        }

        private T setObjectId(T objekt, int id)
        {
            Type myType = objekt.GetType();
            PropertyInfo pinfo = myType.GetProperty("Id");
            pinfo.SetValue(objekt, id, null);
            return objekt;
        }

        private string getfilenamePrefix()
        {
            return datafileprefix;
        }

        private string getfilenameExtension()
        {
            return datafileextension;
        }
    }
}
