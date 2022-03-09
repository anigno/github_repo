namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public class V2VConfigurationExt : V2VConfiguration
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName += "Ext";
            MaxDaysHoldingPos = 35;
            RegularProfitCut = 0.5f;
            IsSystemActive = true;
            
            VolatilityConstant = 60;
            DaysToOptionMaturity = 50;
            OptionsChangePut = 0f;
            OptionsWeightPut = 1f;
        }
    }
    
    public class VxxLConfigurationExt : VxxLConfiguration
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName += "Ext";
            MaxDaysHoldingPos = 35;
            RegularProfitCut = 0.5f;
            IsSystemActive = true;
            
            VolatilityConstant = 60;
            DaysToOptionMaturity = 50;
            OptionsChangePut = 0f;
            OptionsWeightPut = 1f;
        }
    }

    public class VxxSConfigurationExt : VxxSConfiguration
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName += "Ext";
            MaxDaysHoldingPos = 35;
            RegularProfitCut = 0.5f;
            IsSystemActive = true;
            
            VolatilityConstant = 60;
            DaysToOptionMaturity = 50;
            OptionsChangePut = 0f;
            OptionsWeightPut = 1f;
        }
    }

    public class XivLConfigurationExt : XivLConfiguration
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName += "Ext";
            MaxDaysHoldingPos = 40;
            RegularProfitCut = 0.5f;
            IsSystemActive = true;
            NegativeParam = 79;
            
            VolatilityConstant = 60;
            DaysToOptionMaturity = 50;
            OptionsChangePut = 0f;
            OptionsWeightPut = 1f;
        }
    }

    public class XivSConfigurationExt : XivSConfiguration
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName += "Ext";
            MaxDaysHoldingPos = 40;
            RegularProfitCut = 0.5f;
            IsSystemActive = true;
            NegativeParam = 79;

            VolatilityConstant = 60;
            DaysToOptionMaturity = 50;
            OptionsChangePut = 0f;
            OptionsWeightPut = 1f;
        }
    }


}
