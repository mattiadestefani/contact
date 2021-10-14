﻿using System;
using System.Collections.Generic;
using ContactManager;
using GestioneContatti;
using FileHelper;

namespace Handlaer
{
    public class HandlerContatti
    {
        private readonly Manager MyManager;
        private readonly string Path;
        private readonly MyFile MioFile;
        private readonly Traslate MyTranslate;

            public HandlerContatti(string path)
        {
            MyTranslate = new Traslate();
            MioFile = new MyFile();
            Path = path;
        }

        public void Load()
        {
            var listaStringhe = MioFile.GetRows(Path);
            var miaRub = MyTranslate.GetPersone(listaStringhe);
            MyManager = new Manager(miaRub);

    }
}
