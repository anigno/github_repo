using System;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer5.Systems;

namespace AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific
{
    public partial class UserControlSystem : UserControl
    {
        public UserControlSystem()
        {
            InitializeComponent();
        }

        public void SetHistoryAutoGridRowItemType(Type p_type)
        {
            userControlHystorySymbols.SetAutoGridItemType(p_type);
        }

        public void RegisterEvents(AfaSystemBase p_system)
        {
            userControlActiveSymbols.RegisterSystem(p_system);
            userControlGeneralSymbols.RegisterSystem(p_system);
            userControlGeneralSymbols.SelectedSymbolChanged += onUserControlGeneralSymbolsSelectedSymbolChanged;
            userControlHystorySymbols.RegisterSystem(p_system);
        }

        void onUserControlGeneralSymbolsSelectedSymbolChanged(GeneralSymbols.GeneralSymbolItem p_generalSymbolItem)
        {
            userControlHystorySymbols.UpdateHistoryDisplayedData(p_generalSymbolItem.SymbolName);
        }

        public void UnregisterEvents()
        {
        }
    }
}