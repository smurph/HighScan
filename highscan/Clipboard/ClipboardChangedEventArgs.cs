/********************************************
 *
 * Author: dbkk (http://stackoverflow.com/users/838/dbkk)
 *
 * Source: http://stackoverflow.com/a/1394225
 *
 ********************************************/

using System;
using System.Windows.Forms;

namespace HighScan
{
    public class ClipboardChangedEventArgs : EventArgs
    {
        public readonly IDataObject DataObject;

        public ClipboardChangedEventArgs(IDataObject dataObject)
        {
            DataObject = dataObject;
        }
    }
}