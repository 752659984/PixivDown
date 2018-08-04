using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixivDown
{
    /// <summary>
    /// 因为窗口的控件是自动生成的代码，修饰符是private，所以不能实现接口
    /// 如果将private改为public，则页面设计器会出错
    /// </summary>
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
