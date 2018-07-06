using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixivDown
{
    public interface IBaseForm
    {
        RadioButton RadAllFollow { get; set; }
        RadioButton RadSingle { get; set; }
        RadioButton RadCollection { get; set; }

        RadioButton RadDupDir { get; set; }
        RadioButton RadDupLast { get; set; }

        CheckBox ChkNeglect { get; set; }


        Label LblOtherText { get; set; }

        Label LblGetThread { get; set; }
        Label LblDownThread { get; set; }

        RichTextBox RtxtSuccess { get; set; }
        RichTextBox RtxtError { get; set; }

        ComboBox DdlListUrl { get; set; }

        TextBox TxtSavePath { get; set; }
        TextBox TxtCurrListUrl { get; set; }
        TextBox TxtItemUrl { get; set; }

        IAsyncResult BeginInvoke(Delegate method);
        object Invoke(Delegate method);
    }
}
