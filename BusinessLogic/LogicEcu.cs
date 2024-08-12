using CarEdit_server.PublicClasses;
using VoltApi.BusinessLogic.BSM.GM;
using VoltApi.BusinessLogic.Ecu.BMW;
using VoltApi.BusinessLogic.Ecu.CHINA;
using VoltApi.BusinessLogic.Ecu.FCA;
using VoltApi.BusinessLogic.Ecu.FORD;
using VoltApi.BusinessLogic.Ecu.GM;
using VoltApi.BusinessLogic.Ecu.HONDA;
using VoltApi.BusinessLogic.Ecu.IVECO;
using VoltApi.BusinessLogic.Ecu.KIA;
using VoltApi.BusinessLogic.Ecu.LADA;
using VoltApi.BusinessLogic.Ecu.MAHINDRA;
using VoltApi.BusinessLogic.Ecu.MERSEDES;
using VoltApi.BusinessLogic.Ecu.NISSAN;
using VoltApi.BusinessLogic.Ecu.PSA;
using VoltApi.BusinessLogic.Ecu.RENAULT;
using VoltApi.BusinessLogic.Ecu.SUZUKI;
using VoltApi.BusinessLogic.Ecu.TATA;
using VoltApi.BusinessLogic.Ecu.TOYOTA;
using VoltApi.BusinessLogic.Ecu.VAG;
using VoltApi.BusinessLogic.Ecu.VINFAST;
using CarEdit_Server.BusinessLogic.Ecu.FORD;
using CarEdit_Server.BusinessLogic.Ecu.GM;
using CarEdit_Server.BusinessLogic.Ecu.FCA;
using CarEdit_Server.BusinessLogic.Ecu.BMW;
using CarEdit_Server.BusinessLogic.Ecu.VOLVO;
using CarEdit_Server.BusinessLogic.Ecu.PAZ;
using CarEdit_Server.BusinessLogic.Ecu.RENAULT;
using CarEdit_Server.BusinessLogic.Ecu.VAG;
using CarEdit_Server.BusinessLogic.Ecu.KIA;
using CarEdit_Server.BusinessLogic.Ecu.MAZDA;
using CarEdit_Server.BusinessLogic.Ecu.MERSEDES;
using CarEdit_Server.BusinessLogic.Ecu.TOYOTA;
using CarEdit_Server.BusinessLogic.Ecu.JLR;
using CarEdit_Server.BusinessLogic.Ecu.PORSCHE;
using CarEdit_Server.BusinessLogic.Ecu.MITSUBISHI;
using CarEdit_Server.BusinessLogic.Ecu.MAHINDRA;
using CarEdit_Server.BusinessLogic.Ecu.HONDA;
using VoltApi.BusinessLogic.DASH;
using CarEdit_Server.BusinessLogic.Ecu.CHINA;
using VoltApi.BusinessLogic.DASH.BRP;
using CarEdit_Server.BusinessLogic.Ecu.PSA;
using CarEdit_Server.BusinessLogic.Ecu.ISUZU;

namespace VoltApi.BusinessLogic
{
    public class LogicEcu
    {
        public static async Task<DataECU> CheckECUAsync(long userId, string ecuType, string fullPath)
        {
            var response = new DataECU { Message = "DUMP ERROR" };

            switch (ecuType)
            {
                //DASH
                case EcuTypes.D_DASH_BRP_24C02: response = await D_DASH_BRP_24C02.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_DASH_BRP_24C08: response = await D_DASH_BRP_24C08.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_CUMMINS_KM: response = await D_ECU_CUMMINS_KM.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_DASH_FORD_MUSTANG_93C86: response = await D_DASH_FORD_MUSTANG_93C86.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_DASH_GEELY_EMGRAND: response = await D_DASH_GEELY_EMGRAND.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_DASH_KIA_93C46: response = await D_DASH_KIA_93C46.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_DASH_KIA_93C56: response = await D_DASH_KIA_93C56.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_DASH_KIA_93C66: response = await D_DASH_KIA_93C66.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_DASH_KIA_93S56: response = await D_DASH_KIA_93S56.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_DASH_CITROEN_DS7_95160: response = await D_DASH_CITROEN_DS7_95160.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_DASH_TOYOTA_93C66_v1: response = await D_DASH_TOYOTA_93C66_v1.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_DASH_TOYOTA_LC_93C86: response = await D_DASH_TOYOTA_LC_93C86.CheckECUAsync(userId, fullPath); break;
                
                // BSM
                // GM
                case EcuTypes.D_BCM_GM_24C16: response = await D_BCM_GM_24C16.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_BCM_GM_24C32: response = await D_BCM_GM_24C32.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_BCM_GM_BOSCH_70F3558: response = await D_BCM_GM_BOSCH_70F3558.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_SRS_GM_95160v1: response = await D_SRS_GM_95160v1.CheckSRSAsync(userId, fullPath); break;
                //если тип соответствует данному то ждем конца работы плагина
                // BMW   
                case EcuTypes.D_ECU_BMW_MSD81: response = await D_ECU_BMW_MSD81.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_EDC17C41: response = await D_ECU_BMW_EDC17C41.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_BMW_EDC17C45_49: response = await D_ECU_BMW_EDC17C45_49.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_EDC17C50: response = await D_ECU_BMW_EDC17C50.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_EDC17C56: response = await D_ECU_BMW_EDC17C56.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_EDC17C76: response = await D_ECU_BMW_EDC17C76.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_EDC17CP09: response = await D_ECU_BMW_EDC17CP09.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MD1CP002: response = await D_ECU_BMW_MD1CP002.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MD1CS001: response = await D_ECU_BMW_MD1CS001.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MD1CS001_SWAP: response = await D_ECU_BMW_MD1CS001_SWAP.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_ME72: response = await D_ECU_BMW_ME72.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MS42: response = await D_ECU_BMW_MS42.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MS45: response = await D_ECU_BMW_MS45.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MEV1746: response = await D_ECU_BMW_MEV1746.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MEVD1721: response = await D_ECU_BMW_MEVD1721.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MEVD1722: response = await D_ECU_BMW_MEVD1722.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MEVD1723: response = await D_ECU_BMW_MEVD1723.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MEVD1724: response = await D_ECU_BMW_MEVD1724.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MEVD1725: response = await D_ECU_BMW_MEVD1725.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MEVD1726: response = await D_ECU_BMW_MEVD1726.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MEVD1729: response = await D_ECU_BMW_MEVD1729.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MEVD172G: response = await D_ECU_BMW_MEVD172G.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_BMW_MEVD172X: response = await D_ECU_BMW_MEVD172X.CheckECUAsync(userId, fullPath); break;
                // CHINA
                case EcuTypes.D_ECU_CHUNA_MG1CS080: response = await D_ECU_CHUNA_MG1CS080.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_CHUNA_MG1US008: response = await D_ECU_CHUNA_MG1US008.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_CHUNA_MG1UA008: response = await D_ECU_CHUNA_MG1UA008.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_CHINA_ME17810: response = await D_ECU_CHINA_ME17810.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_CHINA_ME1788: response = await D_ECU_CHINA_ME1788.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_CHINA_EDC17C81: response = await D_ECU_CHINA_EDC17C81.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_CHINA: response = await D_ECU_CHINA.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_CHINA_MT92: response = await D_ECU_CHINA_MT92.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_CHINA_MT62: response = await D_ECU_CHINA_MT62.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_CHINA_MT80: response = await D_ECU_CHINA_MT80.CheckECUAsync(userId, fullPath); break;
                // FCA 
                case EcuTypes.D_ECU_FCA_EDC16CP31: response = await D_ECU_FCA_EDC16CP31.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FCA_EDC16C39: response = await D_ECU_FCA_EDC16C39.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FCA_EDC16U31: response = await D_ECU_FCA_EDC16U31.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FCA_EDC17C49: response = await D_ECU_FCA_EDC17C49.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FCA_EDC17C69: response = await D_ECU_FCA_EDC17C69.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FCA_EDC17C79: response = await D_ECU_FCA_EDC17C79.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FCA_GPEG2: response = await D_ECU_FCA_GPEG2.CheckECUAsync(userId, fullPath); break;
                // FORD 

                case EcuTypes.D_ECU_FORD_EEC_5: response = await D_ECU_FORD_EEC_5.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_EEC_6: response = await D_ECU_FORD_EEC_6.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_EEC_6_1MB: response = await D_ECU_FORD_EEC_6_1MB.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_ESU131: response = await D_ECU_FORD_ESU131.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_EMS2204: response = await D_ECU_FORD_EMS2204.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_EMS2205: response = await D_ECU_FORD_EMS2205.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_EMS2208: response = await D_ECU_FORD_EMS2208.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_EMS24XX: response = await D_ECU_FORD_EMS24XX.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_EMS25XX: response = await D_ECU_FORD_EMS25XX.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_MG1XX: response = await D_ECU_FORD_MG1XX.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_MED17: response = await D_ECU_FORD_MED17.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_MEDG17: response = await D_ECU_FORD_MEDG17.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_MG1CS017: response = await D_ECU_FORD_MG1CS017.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_FORD_SID208: response = await D_ECU_FORD_SID208.CheckECUAsync(userId, fullPath); break;

                // IVECO
                case EcuTypes.D_ECU_IVECO_EDC16C39: response = await D_ECU_IVECO_EDC16C39.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_IVECO_EDC17CP52: response = await D_ECU_IVECO_EDC17CP52.CheckECUAsync(userId, fullPath); break;
                // ISUZU
                case EcuTypes.D_ECU_ISUZU_TRANSTRON_4HK1: response = await D_ECU_ISUZU_TRANSTRON_4HK1.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_ISUZU_TRANSTRON_4JJ1: response = await D_ECU_ISUZU_TRANSTRON_4JJ1.CheckECUAsync(userId, fullPath); break;
                // JLR  
                case EcuTypes.D_ECU_JLR_EDC17CP42: response = await D_ECU_JLR_EDC17CP42.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_JLR_EDC17CP55: response = await D_ECU_JLR_EDC17CP55.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_JLR_MED1783: response = await D_ECU_JLR_MED1783.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_JLR_MED1797: response = await D_ECU_JLR_MED1797.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_JLR_MED1799: response = await D_ECU_JLR_MED1799.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_JLR_MEDC179: response = await D_ECU_JLR_MEDC179.CheckECUAsync(userId, fullPath); break;
                // KIA 
                case EcuTypes.D_ECU_KIA_CPEGD2: response = await D_ECU_KIA_CPEGD2.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_EDC15C7: response = await D_ECU_KIA_EDC15C7.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_EDC16CP34: response = await D_ECU_KIA_EDC16CP34.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_ME798: response = await D_ECU_KIA_ME798.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_EDC17CP14: response = await D_ECU_KIA_EDC17CP14.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_EDC17CP62: response = await D_ECU_KIA_EDC17CP62.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_ME17921: response = await D_ECU_KIA_ME17921.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_ME17921_EEE: response = await D_ECU_KIA_ME17921_EEE.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_ME17911: response = await D_ECU_KIA_ME17911.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_EDC17C57: response = await D_ECU_KIA_EDC17C57.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_EDC17C08: response = await D_ECU_KIA_EDC17C08.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_SIM2K141: response = await D_ECU_KIA_SIM2K141.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_SIM2K24X: response = await D_ECU_KIA_SIM2K24X.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_SIM2K25X: response = await D_ECU_KIA_SIM2K25X.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_SIM2K26X: response = await D_ECU_KIA_SIM2K26X.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_MD1CS012: response = await D_ECU_KIA_MD1CS012.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_KIA_DCU17PC43: response = await D_ECU_KIA_DCU17PC43.CheckECUAsync(userId, fullPath); break;
                // LADA  
                case EcuTypes.D_ECU_LADA_ME1797: response = await D_ECU_LADA_ME1797.CheckECUAsync(userId, fullPath); break;
                // MAZDA 
                case EcuTypes.D_ECU_MAZDA_GEN2_DENSO_1024: response = await D_ECU_MAZDA_GEN2_DENSO_1024.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MAZDA_GEN3_DENSO_2048: response = await D_ECU_MAZDA_GEN3_DENSO_2048.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MAZDA_DENSO_DIESEL_2MB: response = await D_ECU_MAZDA_DENSO_DIESEL_2MB.CheckECUAsync(userId, fullPath); break;
                // NISSAN
                case EcuTypes.D_ECU_NISSAN_HITACHI_GEN2: response = await D_ECU_NISSAN_HITACHI_GEN2.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_NISSAN_512: response = await D_ECU_NISSAN_512.CheckECUAsync(userId, fullPath); break;
                // GM 
                case EcuTypes.D_ECU_GM_D42: response = await D_ECU_GM_D42.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_ME799: response = await D_ECU_GM_ME799.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_ME961: response = await D_ECU_GM_ME961.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_E37: response = await D_ECU_GM_E37.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_E38: response = await D_ECU_GM_E38.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_E39: response = await D_ECU_GM_E39.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_E78: response = await D_ECU_GM_E78.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_GM_E80: response = await D_ECU_GM_E80.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_GM_E82: response = await D_ECU_GM_E82.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_E83: response = await D_ECU_GM_E83.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_GM_E87: response = await D_ECU_GM_E87.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_E91: response = await D_ECU_GM_E91.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_E92: response = await D_ECU_GM_E92.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_GM_E98: response = await D_ECU_GM_E98.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_GM_EDC17C59: response = await D_ECU_GM_EDC17C59.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_EDC17CP18: response = await D_ECU_GM_EDC17CP18.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_MG1US008: response = await D_ECU_GM_MG1US008.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_MT80: response = await D_ECU_GM_MT80.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_GM_Simtec_761: response = await D_ECU_GM_Simtec_761.CheckECUAsync(userId, fullPath); break;
                // HONDA 
                case EcuTypes.D_ECU_HONDA_ALL: response = await D_ECU_HONDA_ALL.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_HONDA_1MB: response = await D_ECU_HONDA_1MB.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_HONDA_2MB: response = await D_ECU_HONDA_2MB.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_HONDA_2_5MB: response = await D_ECU_HONDA_2_5MB.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_HONDA_3MB: response = await D_ECU_HONDA_3MB.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_HONDA_3_8MB: response = await D_ECU_HONDA_3_8MB.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_HONDA_MED1793: response = await D_ECU_HONDA_MED1793.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_HONDA_EDC17C58: response = await D_ECU_HONDA_EDC17C58.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_HONDA_EDC17CP50: response = await D_ECU_HONDA_EDC17CP50.CheckECUAsync(userId, fullPath); break;
                // MAHINDRA
                case EcuTypes.D_ECU_MAHINDRA_EDC17C55: response = await D_ECU_MAHINDRA_EDC17C55.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MAHINDRA_EDC17C63: response = await D_ECU_MAHINDRA_EDC17C63.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MAHINDRA_MD1CS018: response = await D_ECU_MAHINDRA_MD1CS018.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MAHINDRA_DCM7_1: response = await D_ECU_MAHINDRA_DCM7_1.CheckECUAsync(userId, fullPath); break;
                // OPEL
                case EcuTypes.D_DASH_OPEL_ASTRA_35080: response = await D_DASH_OPEL_ASTRA_35080.CheckECUAsync(userId, fullPath); break;
                // MAZ
                case EcuTypes.D_ECU_MAZ_EDC7U31: response = await D_ECU_MAZ_EDC7U31.CheckECUAsync(userId, fullPath); break;
                // MB D_ECU_MB_SIM271DE
                case EcuTypes.D_ECU_MB_ME97: response = await D_ECU_MB_ME97.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MB_EDC17C66: response = await D_ECU_MB_EDC17C66.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MB_EDC17CP57: response = await D_ECU_MB_EDC17CP57.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MB_SIM266: response = await D_ECU_MB_SIM266.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MB_SIM271DE: response = await D_ECU_MB_SIM271DE.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MB_SIM271KE: response = await D_ECU_MB_SIM271KE.CheckECUAsync(userId, fullPath); break;
                // MITSUBISHI  
                case EcuTypes.D_ECU_MIT_768: response = await D_ECU_MIT_768.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MITSUBISHI_128: response = await D_ECU_MITSUBISHI_128.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MITSUBISHI_256: response = await D_ECU_MITSUBISHI_256.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MITSUBISHI_512: response = await D_ECU_MITSUBISHI_512.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_MITSUBISHI_768: response = await D_ECU_MITSUBISHI_768.CheckECUAsync(userId, fullPath); break;
                //PAZ 
                case EcuTypes.D_ECU_PAZ_EDC17CV44: response = await D_ECU_PAZ_EDC17CV44.CheckECUAsync(userId, fullPath); break;
                ///PORSCHE
                case EcuTypes.D_ECU_PORSCHE_SDI4: response = await D_ECU_PORSCHE_SDI4.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_PORSCHE_SDI6: response = await D_ECU_PORSCHE_SDI6.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_PORSCHE_SDI8: response = await D_ECU_PORSCHE_SDI8.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_PORSCHE_SDI9: response = await D_ECU_PORSCHE_SDI9.CheckECUAsync(userId, fullPath); break;
                // PSA 
                case EcuTypes.D_ECU_PSA_DCM62: response = await D_ECU_PSA_DCM62.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_PSA_EDC17C60: response = await D_ECU_PSA_EDC17C60.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_PSA_ME17: response = await D_ECU_PSA_ME17.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_PSA_MD1CS003: response = await D_ECU_PSA_MD1CS003.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_PSA_SID208: response = await D_ECU_PSA_SID208.CheckECUAsync(userId, fullPath); break;
                // SUBARU
                case EcuTypes.D_ECU_SUBARU_DENSO_1MB: response = await D_ECU_SUBARU_DENSO_1MB.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_SUBARU_DENSO_1_28MB: response = await D_ECU_SUBARU_DENSO_1_28MB.CheckECUAsync(userId, fullPath); break;
                // SUZUKI  
                case EcuTypes.D_ECU_SUZUKI_MG1CS026: response = await D_ECU_SUZUKI_MG1CS026.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_SUZUKI_ME1795X: response = await D_ECU_SUZUKI_ME1795X.CheckECUAsync(userId, fullPath); break;
                // RENAULT                                                                                                    
                case EcuTypes.D_ECU_RENAULT_EDC17C84: response = await D_ECU_RENAULT_EDC17C84.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_EMS3120: response = await D_ECU_RENAULT_EMS3120.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_EMS3125: response = await D_ECU_RENAULT_EMS3125.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_EMS3132_KLINE: response = await D_ECU_RENAULT_EMS3132_KLINE.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_EMS3140: response = await D_ECU_RENAULT_EMS3140.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_EMS3150: response = await D_ECU_RENAULT_EMS3150.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_EMS3155: response = await D_ECU_RENAULT_EMS3155.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_MD1CS006: response = await D_ECU_RENAULT_MD1CS006.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_MD1CS016: response = await D_ECU_RENAULT_MD1CS016.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_SID305: response = await D_ECU_RENAULT_SID305.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_SID306: response = await D_ECU_RENAULT_SID306.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_SID307: response = await D_ECU_RENAULT_SID307.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_SID310: response = await D_ECU_RENAULT_SID310.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_SIRIUS32_KLINE: response = await D_ECU_RENAULT_SIRIUS32_KLINE.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_RENAULT_VALEO_V40_42: response = await D_ECU_RENAULT_VALEO_V40_42.CheckECUAsync(userId, fullPath); break;
                // TATA
                case EcuTypes.D_ECU_TATA_MD1CS018: response = await D_ECU_TATA_MD1CS018.CheckECUAsync(userId, fullPath); break;
                // TOYOTA
                case EcuTypes.D_ECU_TOYOYA_GEN1: response = await D_ECU_TOYOYA_GEN1.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_TOYOYA_GEN2: response = await D_ECU_TOYOYA_GEN2.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_TOYOYA_GEN3: response = await D_ECU_TOYOYA_GEN3.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_TOYOYA_GEN4: response = await D_ECU_TOYOYA_GEN4.CheckECUAsync(userId, fullPath); break;
                // VAG 
                case EcuTypes.D_ECU_VAG_EDC16: response = await D_ECU_VAG_EDC16.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_VAG_EDC16U3X: response = await D_ECU_VAG_EDC16U3X.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_EDC16CP34: response = await D_ECU_VAG_EDC16CP34.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_EDC17C46: response = await D_ECU_VAG_EDC17C46.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_VAG_EDC17C54: response = await D_ECU_VAG_EDC17C54.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_EDC17C64: response = await D_ECU_VAG_EDC17C64.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_EDC17C74: response = await D_ECU_VAG_EDC17C74.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_EDC17CP14: response = await D_ECU_VAG_EDC17CP14.CheckECUAsync(userId, fullPath); break; 
                case EcuTypes.D_ECU_VAG_EDC17CP20: response = await D_ECU_VAG_EDC17CP20.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_EDC17CP44: response = await D_ECU_VAG_EDC17CP44.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_EDC17CP54: response = await D_ECU_VAG_EDC17CP54.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_EDC17U01: response = await D_ECU_VAG_EDC17U01.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_ME17526: response = await D_ECU_VAG_ME17526.CheckECUAsync(userId, fullPath);break;
                case EcuTypes.D_ECU_VAG_MED91: response = await D_ECU_VAG_MED91.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_MED951: response = await D_ECU_VAG_MED951.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_MED171: response = await D_ECU_VAG_MED171.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_MED1755: response = await D_ECU_VAG_MED1755.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_MED1751: response = await D_ECU_VAG_MED1751.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_MED1752: response = await D_ECU_VAG_MED1752.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_MED17521: response = await D_ECU_VAG_MED17521.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_MED17525: response = await D_ECU_VAG_MED17525.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_ME7510: response = await D_ECU_VAG_ME7510.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_ME711: response = await D_ECU_VAG_ME711.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_MD1CP004: response = await D_ECU_VAG_MD1CP004.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_MG1CS111: response = await D_ECU_VAG_MG1CS111.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_SIMOS_71: response = await D_ECU_VAG_SIMOS_71.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_SIMOS_8: response = await D_ECU_VAG_SIMOS_8.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_SIMOS_9: response = await D_ECU_VAG_SIMOS_9.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_SIMOS_10: response = await D_ECU_VAG_SIMOS_10.CheckECUAsync(userId, fullPath); break;//
                case EcuTypes.D_ECU_VAG_SIMOS_11: response = await D_ECU_VAG_SIMOS_11.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_SIMOS_12: response = await D_ECU_VAG_SIMOS_12.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_SIMOS_18: response = await D_ECU_VAG_SIMOS_18.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_SIMOS3_93C76: response = await D_ECU_VAG_SIMOS3_93C76.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_PCR21: response = await D_ECU_VAG_PCR21.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VAG_SOFTWARE: response = await D_ECU_VAG_SOFTWARE.CheckECUAsync(userId, fullPath); break;
                // VINFAST 
                case EcuTypes.D_ECU_VINFAST_MG1CS088: response = await D_ECU_VINFAST_MG1CS088.CheckECUAsync(userId, fullPath); break;
                // VOLVO 
                case EcuTypes.D_ECU_VOLVO_EDC17CP22: response = await D_ECU_VOLVO_EDC17CP22.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VOLVO_EDC17CP48: response = await D_ECU_VOLVO_EDC17CP48.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VOLVO_EDC17CP68: response = await D_ECU_VOLVO_EDC17CP68.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VOLVO_ME70: response = await D_ECU_VOLVO_ME70.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VOLVO_ME701: response = await D_ECU_VOLVO_ME701.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VOLVO_ME711: response = await D_ECU_VOLVO_ME711.CheckECUAsync(userId, fullPath); break;
                case EcuTypes.D_ECU_VOLVO_MG1CS080: response = await D_ECU_VOLVO_MG1CS080.CheckECUAsync(userId, fullPath); break;

                default: break;
            }

            return response;
        }

        public static async Task<DataECU> Progress(long userId, string ecuType, DataECU request)
        {
            
            switch (ecuType)
            {
                //DASH
                case EcuTypes.D_DASH_BRP_24C02: return await  D_DASH_BRP_24C02.ProgressECUAsync(userId, request); 
                case EcuTypes.D_DASH_BRP_24C08: return await  D_DASH_BRP_24C08.ProgressECUAsync(userId, request); 
                case EcuTypes.D_ECU_CUMMINS_KM: return await  D_ECU_CUMMINS_KM.ProgressECUAsync(userId, request); 
                case EcuTypes.D_DASH_FORD_MUSTANG_93C86: return await  D_DASH_FORD_MUSTANG_93C86.ProgressECUAsync(userId, request); 
                case EcuTypes.D_DASH_GEELY_EMGRAND: return await  D_DASH_GEELY_EMGRAND.ProgressECUAsync(userId, request); 
                case EcuTypes.D_DASH_KIA_93C46: return await  D_DASH_KIA_93C46.ProgressECUAsync(userId, request); 
                case EcuTypes.D_DASH_KIA_93C56: return await  D_DASH_KIA_93C56.ProgressECUAsync(userId, request); 
                case EcuTypes.D_DASH_KIA_93C66: return await  D_DASH_KIA_93C66.ProgressECUAsync(userId, request); 
                case EcuTypes.D_DASH_KIA_93S56: return await  D_DASH_KIA_93S56.ProgressECUAsync(userId, request); 
                case EcuTypes.D_DASH_CITROEN_DS7_95160: return await  D_DASH_CITROEN_DS7_95160.ProgressECUAsync(userId, request); 
                case EcuTypes.D_DASH_TOYOTA_93C66_v1: return await  D_DASH_TOYOTA_93C66_v1.ProgressECUAsync(userId, request); 
                case EcuTypes.D_DASH_TOYOTA_LC_93C86: return await  D_DASH_TOYOTA_LC_93C86.ProgressECUAsync(userId, request); 
                // BSM
                //GM
                case EcuTypes.D_BCM_GM_24C16: return await D_BCM_GM_24C16.ProgressECUAsync(userId, request);
                case EcuTypes.D_BCM_GM_24C32: return await D_BCM_GM_24C32.ProgressECUAsync(userId, request);
                case EcuTypes.D_BCM_GM_BOSCH_70F3558: return await D_BCM_GM_BOSCH_70F3558.ProgressECUAsync(userId, request);
                case EcuTypes.D_SRS_GM_95160v1: return await D_SRS_GM_95160v1.ProgressSRSAsync(userId, request);
                //если тип соответствует данному то ждем конца работы плагина  

                // BMW 
                case EcuTypes.D_ECU_BMW_EDC17C41: return await D_ECU_BMW_EDC17C41.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_EDC17C45_49: return await D_ECU_BMW_EDC17C45_49.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_EDC17C50: return await D_ECU_BMW_EDC17C50.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_EDC17C56: return await D_ECU_BMW_EDC17C56.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_EDC17C76: return await D_ECU_BMW_EDC17C76.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_EDC17CP09: return await D_ECU_BMW_EDC17CP09.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MD1CP002: return await D_ECU_BMW_MD1CP002.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MD1CS001: return await D_ECU_BMW_MD1CS001.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MD1CS001_SWAP: return await D_ECU_BMW_MD1CS001_SWAP.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MSD81: return await D_ECU_BMW_MSD81.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_ME72: return await D_ECU_BMW_ME72.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MS42: return await D_ECU_BMW_MS42.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MS45: return await D_ECU_BMW_MS45.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MEV1746: return await D_ECU_BMW_MEV1746.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MEVD1721: return await D_ECU_BMW_MEVD1721.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MEVD1722: return await D_ECU_BMW_MEVD1722.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MEVD1723: return await D_ECU_BMW_MEVD1723.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MEVD1724: return await D_ECU_BMW_MEVD1724.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MEVD1725: return await D_ECU_BMW_MEVD1725.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MEVD1726: return await D_ECU_BMW_MEVD1726.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MEVD1729: return await D_ECU_BMW_MEVD1729.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MEVD172G: return await D_ECU_BMW_MEVD172G.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_BMW_MEVD172X: return await D_ECU_BMW_MEVD172X.ProgressECUAsync(userId, request);
                // CHINA
                case EcuTypes.D_ECU_CHINA_ME17810: return await D_ECU_CHINA_ME1788.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_CHINA_ME1788: return await D_ECU_CHINA_ME1788.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_CHINA: return await D_ECU_CHINA.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_CHUNA_MG1CS080: return await D_ECU_CHUNA_MG1CS080.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_CHUNA_MG1US008: return await D_ECU_CHUNA_MG1US008.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_CHUNA_MG1UA008: return await D_ECU_CHUNA_MG1UA008.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_CHINA_EDC17C81: return await D_ECU_CHINA_EDC17C81.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_CHINA_MT92: return await D_ECU_CHINA_MT92.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_CHINA_MT62: return await D_ECU_CHINA_MT62.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_CHINA_MT80: return await D_ECU_CHINA_MT80.ProgressECUAsync(userId, request);
                //FCA  
                case EcuTypes.D_ECU_FCA_EDC16CP31: return await D_ECU_FCA_EDC16CP31.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FCA_EDC16C39: return await D_ECU_FCA_EDC16C39.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FCA_EDC16U31: return await D_ECU_FCA_EDC16U31.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FCA_EDC17C49: return await D_ECU_FCA_EDC17C49.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FCA_EDC17C69: return await D_ECU_FCA_EDC17C69.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FCA_EDC17C79: return await D_ECU_FCA_EDC17C79.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FCA_GPEG2: return await D_ECU_FCA_GPEG2.ProgressECUAsync(userId, request);
                //FORD 
                case EcuTypes.D_ECU_FORD_EMS24XX: return await D_ECU_FORD_EMS24XX.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_EEC_5: return await D_ECU_FORD_EEC_5.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_EEC_6: return await D_ECU_FORD_EEC_6.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_EEC_6_1MB: return await D_ECU_FORD_EEC_6_1MB.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_ESU131: return await D_ECU_FORD_ESU131.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_EMS2204: return await D_ECU_FORD_EMS2204.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_EMS2205: return await D_ECU_FORD_EMS2205.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_EMS2208: return await D_ECU_FORD_EMS2208.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_EMS25XX: return await D_ECU_FORD_EMS25XX.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_MG1XX: return await D_ECU_FORD_MG1XX.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_MED17: return await D_ECU_FORD_MED17.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_MEDG17: return await D_ECU_FORD_MEDG17.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_MG1CS017: return await D_ECU_FORD_MG1CS017.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_FORD_SID208: return await D_ECU_FORD_SID208.ProgressECUAsync(userId, request);
                // GM 
                case EcuTypes.D_ECU_GM_D42: return await D_ECU_GM_D42.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_ME799: return await D_ECU_GM_ME799.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_ME961: return await D_ECU_GM_ME961.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_E37: return await D_ECU_GM_E37.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_E38: return await D_ECU_GM_E38.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_E39: return await D_ECU_GM_E39.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_E78: return await D_ECU_GM_E78.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_E80: return await D_ECU_GM_E80.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_E82: return await D_ECU_GM_E82.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_E83: return await D_ECU_GM_E83.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_E87: return await D_ECU_GM_E87.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_E91: return await D_ECU_GM_E91.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_E92: return await D_ECU_GM_E92.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_E98: return await D_ECU_GM_E98.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_EDC17C59: return await D_ECU_GM_EDC17C59.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_EDC17CP18: return await D_ECU_GM_EDC17CP18.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_MG1US008: return await D_ECU_GM_MG1US008.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_MT80: return await D_ECU_GM_MT80.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_GM_Simtec_761: return await D_ECU_GM_Simtec_761.ProgressECUAsync(userId, request);

                // HONDA  
                case EcuTypes.D_ECU_HONDA_ALL: return await D_ECU_HONDA_ALL.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_HONDA_1MB: return await D_ECU_HONDA_1MB.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_HONDA_2MB: return await D_ECU_HONDA_2MB.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_HONDA_2_5MB: return await D_ECU_HONDA_2_5MB.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_HONDA_3MB: return await D_ECU_HONDA_3MB.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_HONDA_3_8MB: return await D_ECU_HONDA_3_8MB.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_HONDA_MED1793: return await D_ECU_HONDA_MED1793.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_HONDA_EDC17C58: return await D_ECU_HONDA_EDC17C58.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_HONDA_EDC17CP50: return await D_ECU_HONDA_EDC17CP50.ProgressECUAsync(userId, request);
                // IVECO 
                case EcuTypes.D_ECU_IVECO_EDC16C39: return await D_ECU_IVECO_EDC16C39.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_IVECO_EDC17CP52: return await D_ECU_IVECO_EDC17CP52.ProgressECUAsync(userId, request);
                //ISUZU
                case EcuTypes.D_ECU_ISUZU_TRANSTRON_4HK1: return await D_ECU_ISUZU_TRANSTRON_4HK1.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_ISUZU_TRANSTRON_4JJ1: return await D_ECU_ISUZU_TRANSTRON_4JJ1.ProgressECUAsync(userId, request);
                // JLR 
                case EcuTypes.D_ECU_JLR_EDC17CP42: return await D_ECU_JLR_EDC17CP42.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_JLR_EDC17CP55: return await D_ECU_JLR_EDC17CP55.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_JLR_MED1783: return await D_ECU_JLR_MED1783.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_JLR_MED1797: return await D_ECU_JLR_MED1797.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_JLR_MED1799: return await D_ECU_JLR_MED1799.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_JLR_MEDC179: return await D_ECU_JLR_MEDC179.ProgressECUAsync(userId, request);
                // KIA  
                case EcuTypes.D_ECU_KIA_CPEGD2: return await D_ECU_KIA_CPEGD2.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_EDC15C7: return await D_ECU_KIA_EDC15C7.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_EDC16CP34: return await D_ECU_KIA_EDC16CP34.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_ME798: return await D_ECU_KIA_ME798.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_EDC17CP14: return await D_ECU_KIA_EDC17CP14.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_EDC17CP62: return await D_ECU_KIA_EDC17CP62.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_ME17921: return await D_ECU_KIA_ME17921.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_ME17921_EEE: return await D_ECU_KIA_ME17921_EEE.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_ME17911: return await D_ECU_KIA_ME17911.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_EDC17C57: return await D_ECU_KIA_EDC17C57.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_EDC17C08: return await D_ECU_KIA_EDC17C08.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_SIM2K141: return await D_ECU_KIA_SIM2K141.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_SIM2K24X: return await D_ECU_KIA_SIM2K24X.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_SIM2K25X: return await D_ECU_KIA_SIM2K25X.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_SIM2K26X: return await D_ECU_KIA_SIM2K26X.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_MD1CS012: return await D_ECU_KIA_MD1CS012.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_KIA_DCU17PC43: return await D_ECU_KIA_DCU17PC43.ProgressECUAsync(userId, request);
                // LADA
                case EcuTypes.D_ECU_LADA_ME1797: return await D_ECU_LADA_ME1797.ProgressECUAsync(userId, request);
                // MAZDA 
                case EcuTypes.D_ECU_MAZDA_GEN2_DENSO_1024: return await D_ECU_MAZDA_GEN2_DENSO_1024.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MAZDA_GEN3_DENSO_2048: return await D_ECU_MAZDA_GEN3_DENSO_2048.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MAZDA_DENSO_DIESEL_2MB: return await D_ECU_MAZDA_DENSO_DIESEL_2MB.ProgressECUAsync(userId, request);
                // NISSAN
                case EcuTypes.D_ECU_NISSAN_HITACHI_GEN2: return await D_ECU_NISSAN_HITACHI_GEN2.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_NISSAN_512: return await D_ECU_NISSAN_512.ProgressECUAsync(userId, request);
                // OPEL
                case EcuTypes.D_DASH_OPEL_ASTRA_35080: return await D_DASH_OPEL_ASTRA_35080.ProgressECUAsync(userId, request);
                // MAHINDRA 
                case EcuTypes.D_ECU_MAHINDRA_EDC17C55: return await D_ECU_MAHINDRA_EDC17C55.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MAHINDRA_EDC17C63: return await D_ECU_MAHINDRA_EDC17C63.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MAHINDRA_MD1CS018: return await D_ECU_MAHINDRA_MD1CS018.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MAHINDRA_DCM7_1: return await D_ECU_MAHINDRA_DCM7_1.ProgressECUAsync(userId, request);
                // MAZ 
                case EcuTypes.D_ECU_MAZ_EDC7U31: return await D_ECU_MAZ_EDC7U31.ProgressECUAsync(userId, request);
                //MB 
                case EcuTypes.D_ECU_MB_ME97: return await D_ECU_MB_ME97.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MB_EDC17C66: return await D_ECU_MB_EDC17C66.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MB_EDC17CP57: return await D_ECU_MB_EDC17CP57.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MB_SIM266: return await D_ECU_MB_SIM266.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MB_SIM271DE: return await D_ECU_MB_SIM271DE.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MB_SIM271KE: return await D_ECU_MB_SIM271KE.ProgressECUAsync(userId, request);
                //MIT  
                case EcuTypes.D_ECU_MIT_768: return await D_ECU_MIT_768.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MITSUBISHI_128: return await D_ECU_MITSUBISHI_128.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MITSUBISHI_256: return await D_ECU_MITSUBISHI_256.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MITSUBISHI_512: return await D_ECU_MITSUBISHI_512.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_MITSUBISHI_768: return await D_ECU_MITSUBISHI_768.ProgressECUAsync(userId, request);
                //PAZ D_ECU_PAZ_EDC17CV44
                case EcuTypes.D_ECU_PAZ_EDC17CV44: return await D_ECU_PAZ_EDC17CV44.ProgressECUAsync(userId, request);
                //PORSCHE
                case EcuTypes.D_ECU_PORSCHE_SDI4: return await D_ECU_PORSCHE_SDI4.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_PORSCHE_SDI6: return await D_ECU_PORSCHE_SDI6.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_PORSCHE_SDI8: return await D_ECU_PORSCHE_SDI8.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_PORSCHE_SDI9: return await D_ECU_PORSCHE_SDI9.ProgressECUAsync(userId, request);
                // PSA  
                case EcuTypes.D_ECU_PSA_DCM62: return await D_ECU_PSA_DCM62.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_PSA_EDC17C60: return await D_ECU_PSA_EDC17C60.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_PSA_ME17: return await D_ECU_PSA_ME17.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_PSA_MD1CS003: return await D_ECU_PSA_MD1CS003.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_PSA_SID208: return await D_ECU_PSA_SID208.ProgressECUAsync(userId, request);
                // RENAULT D_ECU_RENAULT_SIRIUS32_KLINE
                case EcuTypes.D_ECU_RENAULT_EDC17C84: return await D_ECU_RENAULT_EDC17C84.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_EMS3120: return await D_ECU_RENAULT_EMS3120.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_EMS3125: return await D_ECU_RENAULT_EMS3125.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_EMS3132_KLINE: return await D_ECU_RENAULT_EMS3132_KLINE.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_EMS3140: return await D_ECU_RENAULT_EMS3150.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_EMS3150: return await D_ECU_RENAULT_EMS3140.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_EMS3155: return await D_ECU_RENAULT_EMS3155.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_MD1CS006: return await D_ECU_RENAULT_MD1CS006.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_MD1CS016: return await D_ECU_RENAULT_MD1CS016.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_SID305: return await D_ECU_RENAULT_SID305.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_SID306: return await D_ECU_RENAULT_SID306.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_SID307: return await D_ECU_RENAULT_SID307.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_SID310: return await D_ECU_RENAULT_SID310.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_SIRIUS32_KLINE: return await D_ECU_RENAULT_SIRIUS32_KLINE.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_RENAULT_VALEO_V40_42: return await D_ECU_RENAULT_VALEO_V40_42.ProgressECUAsync(userId, request);
                // SUBARU
                case EcuTypes.D_ECU_SUBARU_DENSO_1MB: return await D_ECU_SUBARU_DENSO_1MB.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_SUBARU_DENSO_1_28MB: return await D_ECU_SUBARU_DENSO_1_28MB.ProgressECUAsync(userId, request);
                // SUZUKI  
                case EcuTypes.D_ECU_SUZUKI_MG1CS026: return await D_ECU_SUZUKI_MG1CS026.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_SUZUKI_ME1795X: return await D_ECU_SUZUKI_ME1795X.ProgressECUAsync(userId, request);
                // TATA
                case EcuTypes.D_ECU_TATA_MD1CS018: return await D_ECU_TATA_MD1CS018.ProgressECUAsync(userId, request);
                // TOYOTA
                case EcuTypes.D_ECU_TOYOYA_GEN1: return await D_ECU_TOYOYA_GEN1.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_TOYOYA_GEN2: return await D_ECU_TOYOYA_GEN2.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_TOYOYA_GEN3: return await D_ECU_TOYOYA_GEN3.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_TOYOYA_GEN4: return await D_ECU_TOYOYA_GEN4.ProgressECUAsync(userId, request);
                // VAG 
                case EcuTypes.D_ECU_VAG_EDC16: return await D_ECU_VAG_EDC16.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_EDC16U3X: return await D_ECU_VAG_EDC16U3X.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_EDC16CP34: return await D_ECU_VAG_EDC16CP34.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_EDC17C46: return await D_ECU_VAG_EDC17C46.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_EDC17C54: return await D_ECU_VAG_EDC17C54.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_EDC17C64: return await D_ECU_VAG_EDC17C64.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_EDC17C74: return await D_ECU_VAG_EDC17C74.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_EDC17CP14: return await D_ECU_VAG_EDC17CP14.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_EDC17CP20: return await D_ECU_VAG_EDC17CP20.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_EDC17CP44: return await D_ECU_VAG_EDC17CP44.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_EDC17CP54: return await D_ECU_VAG_EDC17CP54.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_EDC17U01: return await D_ECU_VAG_EDC17U01.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_ME17526: return await D_ECU_VAG_ME17526.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_MED91: return await D_ECU_VAG_MED91.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_MED951: return await D_ECU_VAG_MED951.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_MED171: return await D_ECU_VAG_MED171.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_MED1755: return await D_ECU_VAG_MED1755.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_MED1751: return await D_ECU_VAG_MED1751.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_MED1752: return await D_ECU_VAG_MED1752.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_MED17521: return await D_ECU_VAG_MED17521.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_MED17525: return await D_ECU_VAG_MED17525.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_ME7510: return await D_ECU_VAG_ME7510.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_ME711: return await D_ECU_VAG_ME711.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_MD1CP004: return await D_ECU_VAG_MD1CP004.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_MG1CS111: return await D_ECU_VAG_MG1CS111.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_SIMOS_71: return await D_ECU_VAG_SIMOS_71.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_SIMOS_8: return await D_ECU_VAG_SIMOS_8.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_SIMOS_9: return await D_ECU_VAG_SIMOS_9.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_SIMOS_10: return await D_ECU_VAG_SIMOS_10.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_SIMOS_11: return await D_ECU_VAG_SIMOS_11.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_SIMOS_12: return await D_ECU_VAG_SIMOS_12.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_SIMOS_18: return await D_ECU_VAG_SIMOS_18.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_SIMOS3_93C76: return await D_ECU_VAG_SIMOS3_93C76.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_PCR21: return await D_ECU_VAG_PCR21.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VAG_SOFTWARE: return await D_ECU_VAG_SOFTWARE.ProgressECUAsync(userId, request);
                // VINFAST 
                case EcuTypes.D_ECU_VINFAST_MG1CS088: return await D_ECU_VINFAST_MG1CS088.ProgressECUAsync(userId, request);
                // VOLVO  
                case EcuTypes.D_ECU_VOLVO_EDC17CP22: return await D_ECU_VOLVO_EDC17CP22.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VOLVO_EDC17CP48: return await D_ECU_VOLVO_EDC17CP48.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VOLVO_EDC17CP68: return await D_ECU_VOLVO_EDC17CP68.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VOLVO_ME70: return await D_ECU_VOLVO_ME70.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VOLVO_ME701: return await D_ECU_VOLVO_ME701.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VOLVO_ME711: return await D_ECU_VOLVO_ME711.ProgressECUAsync(userId, request);
                case EcuTypes.D_ECU_VOLVO_MG1CS080: return await D_ECU_VOLVO_MG1CS080.ProgressECUAsync(userId, request);
                default: break;
            }

            //если пришла херня то и херню отправляем
            return await FuckResponse();

        }

        private async static Task<DataECU> FuckResponse()
        {
            await Task.Delay(1);
            return new DataECU { Message = "Ошибка запроса" };
        }
    }
}