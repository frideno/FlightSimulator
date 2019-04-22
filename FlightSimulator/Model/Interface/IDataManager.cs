﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    interface IDataManager
    {
		IServer InfoChannel { get; }
		IClient CommandChannel { get; }
		IDictionary<string, double> InfoDataDictionary { get; set; }
	}
}
