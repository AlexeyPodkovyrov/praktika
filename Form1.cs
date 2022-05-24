using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication34
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }       

        private void MainInfo(object sender, EventArgs e)
        {
            textBox1.Clear();
            ManagementClass MainInfoClass = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection MainInfoCollection = MainInfoClass.GetInstances();
            string pctype = null;
            string pcname = null;
            string username = null;
            foreach (ManagementObject MainInfoObject in MainInfoCollection)
            {
                pctype = MainInfoObject.Properties["SystemType"].Value.ToString() + Environment.NewLine;
                pcname = MainInfoObject.Properties["Name"].Value.ToString() + Environment.NewLine;
                username = MainInfoObject.Properties["UserName"].Value.ToString() + Environment.NewLine;
                break;
            }
            textBox1.Text += "Тип компьютера: " + pctype;
            textBox1.Text += "Имя компьютера: " + pcname;
            textBox1.Text += "Имя пользователя: " + username;

            ManagementClass MainInfoClassOS = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection MainInfoCollectionOS = MainInfoClassOS.GetInstances();
            string os = null;
            string paket = null;
            foreach (ManagementObject MainInfoObjectOS in MainInfoCollectionOS)
            {
                os = MainInfoObjectOS.Properties["Caption"].Value.ToString() + Environment.NewLine;
                paket = MainInfoObjectOS.Properties["ServicePackMajorVersion"].Value.ToString();
                break;
            }
            textBox1.Text += "Операционная система: " + os;
            textBox1.Text += "Пакет обновления ОС : " + paket;    
        }

        private void Processor(object sender, EventArgs e)
        {
            textBox1.Clear();
            ManagementClass ProcessorClass = new ManagementClass("Win32_Processor");
            ManagementObjectCollection ProcessorCollection = ProcessorClass.GetInstances();
            string procname = null;
            string procmanufact = null;
            string procdescript = null;
            string proccores = null;
            foreach (ManagementObject ProcessorObject in ProcessorCollection)
            {
                procname = ProcessorObject.Properties["Name"].Value.ToString() + Environment.NewLine;
                procmanufact = ProcessorObject.Properties["Manufacturer"].Value.ToString() + Environment.NewLine;
                procdescript = ProcessorObject.Properties["Description"].Value.ToString() + Environment.NewLine;
                proccores = ProcessorObject.Properties["NumberOfCores"].Value.ToString();
                break;
            }
            textBox1.Text += "Процессор: " + procname;
            textBox1.Text += "Производитель: " + procmanufact;
            textBox1.Text += "Описание: " + procdescript;
            textBox1.Text += "Количество ядер: " + proccores;
        }

        private void MotherBoard(object sender, EventArgs e)
        {
            textBox1.Clear();
            ManagementClass MotherBoardClass = new ManagementClass("Win32_BaseBoard");
            ManagementObjectCollection MotherBoardCollection = MotherBoardClass.GetInstances();
            string boardname = null;
            string boardmanufact = null;
            foreach (ManagementObject MotherBoardObject in MotherBoardCollection)
            {
                boardname = MotherBoardObject.Properties["Product"].Value.ToString() + Environment.NewLine;
                boardmanufact = MotherBoardObject.Properties["Manufacturer"].Value.ToString(); 
                break;
            }
            textBox1.Text += "Системная плата: " + boardname;
            textBox1.Text += "Производитель: " + boardmanufact;
        }

        private void Memory(object sender, EventArgs e)
        {
            textBox1.Clear();
            ManagementClass MemoryClass = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection MemoryCollection= MemoryClass.GetInstances();
            string memsize = null;
            string memspeed = null;
            foreach (ManagementObject MemoryObject in MemoryCollection)
            {
                memsize = MemoryObject.Properties["Capacity"].Value.ToString() + Environment.NewLine;
                memspeed = MemoryObject.Properties["Speed"].Value.ToString();
                break;
            }
            textBox1.Text += "Физическая память: " + Math.Round(System.Convert.ToDouble(memsize) / 1024 / 1024 / 1024, 2) + " ГБ" + Environment.NewLine;
            textBox1.Text += "Скорость памяти: " + memspeed;
        }

        private void VideoCard(object sender, EventArgs e)
        {
            textBox1.Clear();
            ManagementClass VideoCardClass = new ManagementClass("Win32_VideoController");
            ManagementObjectCollection VideoCardCollection = VideoCardClass.GetInstances();
            string videoname = null;
            string videomemory = null;
            string videodriver = null;
            foreach (ManagementObject VideoCardObject in VideoCardCollection)
            {
                videoname = VideoCardObject.Properties["Caption"].Value.ToString() + Environment.NewLine;
                videomemory = VideoCardObject.Properties["AdapterRAM"].Value.ToString() + Environment.NewLine;
                videodriver = VideoCardObject.Properties["DriverVersion"].Value.ToString();
                break;
            }
            textBox1.Text += "Видеоадаптер: " + videoname;
            textBox1.Text += "Объем видеопамяти: " + Math.Round(System.Convert.ToDouble(videomemory) / 1024 / 1024 / 1024, 2) + " ГБ" + Environment.NewLine;
            textBox1.Text += "Версия драйвера: " + videodriver;
        }

        private void DataStorage(object sender, EventArgs e)
        {
            textBox1.Clear();
            ManagementClass DataStorageClass = new ManagementClass("Win32_PhysicalMedia");
            ManagementObjectCollection DataStorageCollection = DataStorageClass.GetInstances();
            string serialnum = null;
            foreach (ManagementObject DataStorageObject in DataStorageCollection)
            {
                serialnum = DataStorageObject.Properties["SerialNumber"].Value.ToString() + Environment.NewLine;
                break;
            }
            textBox1.Text += "Серийный номер: " + serialnum;

            ManagementClass DataStorageClassHDD = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection DataStorageCollectionHDD = DataStorageClassHDD.GetInstances();
            string hddid = null;
            string hddver = null;
            string hddtype = null;
            string hddsize = null;
            foreach (ManagementObject DataStorageObjectHDD in DataStorageCollectionHDD)
            {
                hddid = DataStorageObjectHDD.Properties["Model"].Value.ToString() + Environment.NewLine;
                hddver = DataStorageObjectHDD.Properties["FirmwareRevision"].Value.ToString() + Environment.NewLine;
                hddtype = DataStorageObjectHDD.Properties["InterfaceType"].Value.ToString() + Environment.NewLine;
                hddsize = DataStorageObjectHDD.Properties["Size"].Value.ToString();
                break;
            }
            textBox1.Text += "ID модели: " + hddid;
            textBox1.Text += "Версия: " + hddver;
            textBox1.Text += "Тип интерфейса: " + hddtype;
            textBox1.Text += "Объем памяти: " + Math.Round(System.Convert.ToDouble(hddsize) / 1024 / 1024 / 1024, 2) + " ГБ" + Environment.NewLine + Environment.NewLine;

            ManagementClass DataStorageClassLogDisk = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection DataStorageCollectionLogDisk = DataStorageClassLogDisk.GetInstances();
            string logdiskname = null;
            string logdisknamegb = null;
            string logdiskfile = null;
            string logdisksize = null;
            string logdiskfree = null;
            foreach (ManagementObject DataStorageObjectLogDisk in DataStorageCollectionLogDisk)
            {
                logdiskname = DataStorageObjectLogDisk.Properties["Caption"].Value.ToString();
                logdisknamegb = DataStorageObjectLogDisk.Properties["VolumeName"].Value.ToString() + Environment.NewLine;
                logdiskfile = DataStorageObjectLogDisk.Properties["FileSystem"].Value.ToString() + Environment.NewLine;
                logdisksize = DataStorageObjectLogDisk.Properties["Size"].Value.ToString() + Environment.NewLine;
                logdiskfree = DataStorageObjectLogDisk.Properties["FreeSpace"].Value.ToString();
                break;
            }
            textBox1.Text += "Логический диск: " + logdiskname + " " + logdisknamegb;
            textBox1.Text += "Файловая система: " + logdiskfile;
            textBox1.Text += "Общий объем: " + Math.Round(System.Convert.ToDouble(logdisksize) / 1024 / 1024 / 1024, 2) + " ГБ" + Environment.NewLine;
            textBox1.Text += "Свободное место: " + Math.Round(System.Convert.ToDouble(logdiskfree) / 1024 / 1024 / 1024, 2) + " ГБ";
        }

        private void Monitor(object sender, EventArgs e)
        {
            textBox1.Clear();
            ManagementClass MonitorClass = new ManagementClass("Win32_DesktopMonitor");
            ManagementObjectCollection MonitorCollection = MonitorClass.GetInstances();
            string monitorname = null;
            string monitormanufact = null;
            foreach (ManagementObject MonitorObject in MonitorCollection)
            {
                monitorname = MonitorObject.Properties["Caption"].Value.ToString() + Environment.NewLine;
                monitormanufact = MonitorObject.Properties["MonitorManufacturer"].Value.ToString() + Environment.NewLine;
                break;
            }
            textBox1.Text += "Название: " + monitorname;
            textBox1.Text += "Производитель: " + monitormanufact;

            ManagementClass MonitorClassRate = new ManagementClass("Win32_DisplayControllerConfiguration");
            ManagementObjectCollection MonitorCollectionRate = MonitorClassRate.GetInstances();
            string monitorrate = null;
            foreach (ManagementObject MonitorObjectRate in MonitorCollectionRate)
            {
                monitorrate = MonitorObjectRate.Properties["RefreshRate"].Value.ToString();
                break;
            }
            textBox1.Text += "Частота кадров: " + monitorrate + " Гц";
            textBox1.Text += Environment.NewLine;

            ManagementClass MonitorClassResolution = new ManagementClass("Win32_VideoController");
            ManagementObjectCollection MonitorCollectionResolution = MonitorClassResolution.GetInstances();
            string monitorhorizontal = null;
            string monitorvertical = null;
            foreach (ManagementObject MonitorObjectResolution in MonitorCollectionResolution)
            {
                monitorhorizontal = MonitorObjectResolution.Properties["CurrentHorizontalResolution"].Value.ToString();
                monitorvertical = MonitorObjectResolution.Properties["CurrentVerticalResolution"].Value.ToString() + Environment.NewLine;
                break;
            }
            textBox1.Text += "Максимальное разрешение: " + monitorhorizontal + "x" + monitorvertical;
        }

        private void BIOS(object sender, EventArgs e)
        {
            textBox1.Clear();
            ManagementClass BIOSClass = new ManagementClass("Win32_BIOS");
            ManagementObjectCollection BIOSCollection = BIOSClass.GetInstances();
            string biosdescript = null;
            string biosveros = null;
            string biosmanufact = null;
            string biosver = null;
            string biosversmmajor = null;
            string biosversmminor = null;
            foreach (ManagementObject BIOSObject in BIOSCollection)
            {
                biosdescript = BIOSObject.Properties["Description"].Value.ToString();
                biosveros = BIOSObject.Properties["Version"].Value.ToString() + Environment.NewLine;
                biosmanufact = BIOSObject.Properties["Manufacturer"].Value.ToString() + Environment.NewLine;
                biosver = BIOSObject.Properties["SMBIOSBIOSVersion"].Value.ToString() + Environment.NewLine;
                biosversmmajor = BIOSObject.Properties["SMBIOSMajorVersion"].Value.ToString();
                biosversmminor = BIOSObject.Properties["SMBIOSMinorVersion"].Value.ToString();
                break;
            }
            textBox1.Text += "Дата и версия BIOS ситемы: " + biosdescript + " " + biosveros;
            textBox1.Text += "Производитель: " + biosmanufact;
            textBox1.Text += "Версия BIOS: " + biosver;
            textBox1.Text += "Версия SMBIOS: " + biosversmmajor + "." + biosversmminor;
        }

        private void RunningProcesses(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text += "Запущенные процессы:" + Environment.NewLine;
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {              
                textBox1.Text += process.ProcessName + Environment.NewLine;
            }           
        }

        //Работа с БД
        private void ImportDB(object sender, EventArgs e)
        {
            try
            {
                //Путь для подключения к БД
                string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=pc_info;";     
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                ManagementClass MainInfoClass = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection MainInfoCollection = MainInfoClass.GetInstances();
                string pctype = null;
                string pcname = null;
                string username = null;
                foreach (ManagementObject MainInfoObject in MainInfoCollection)
                {
                    pctype = MainInfoObject.Properties["SystemType"].Value.ToString() + Environment.NewLine;
                    pcname = MainInfoObject.Properties["Name"].Value.ToString() + Environment.NewLine;
                    username = MainInfoObject.Properties["UserName"].Value.ToString() + Environment.NewLine;
                    break;
                }                  
                ManagementClass MainInfoClassOS = new ManagementClass("Win32_OperatingSystem");
                ManagementObjectCollection MainInfoCollectionOS = MainInfoClassOS.GetInstances();
                string os = null;
                string paket = null;
                foreach (ManagementObject MainInfoObjectOS in MainInfoCollectionOS)
                {
                    os = MainInfoObjectOS.Properties["Caption"].Value.ToString() + Environment.NewLine;
                    paket = MainInfoObjectOS.Properties["ServicePackMajorVersion"].Value.ToString();
                    break;
                }
                string maininformation = "INSERT INTO main_information (PC_Type, PC_Name, User_Name, Operating_System, Service_Pack) VALUES ('" + pctype + "', '" + pcname + "', '" + username + "' , '" + os + "' , '" + paket + "')";

                ManagementClass ProcessorClass = new ManagementClass("Win32_Processor");
                ManagementObjectCollection ProcessorCollection = ProcessorClass.GetInstances();
                string procname = null;
                string procmanufact = null;
                string procdescript = null;
                string proccores = null;
                foreach (ManagementObject ProcessorObject in ProcessorCollection)
                {
                    procname = ProcessorObject.Properties["Name"].Value.ToString() + Environment.NewLine;
                    procmanufact = ProcessorObject.Properties["Manufacturer"].Value.ToString() + Environment.NewLine;
                    procdescript = ProcessorObject.Properties["Description"].Value.ToString() + Environment.NewLine;
                    proccores = ProcessorObject.Properties["NumberOfCores"].Value.ToString();
                    break;
                }
                string processor = "INSERT INTO processor (Name, Manufacturer, Description, Number_of_cores) VALUES ('" + procname + "', '" + procmanufact + "', '" + procdescript + "' , '" + proccores + "')";

                ManagementClass MotherBoardClass = new ManagementClass("Win32_BaseBoard");
                ManagementObjectCollection MotherBoardCollection = MotherBoardClass.GetInstances();
                string boardname = null;
                string boardmanufact = null;
                foreach (ManagementObject MotherBoardObject in MotherBoardCollection)
                {
                    boardname = MotherBoardObject.Properties["Product"].Value.ToString() + Environment.NewLine;
                    boardmanufact = MotherBoardObject.Properties["Manufacturer"].Value.ToString();
                    break;
                }
                string motherboard = "INSERT INTO motherboard (Name, Manufacturer) VALUES ('"+ boardname +"','"+ boardmanufact +"')";

                ManagementClass MemoryClass = new ManagementClass("Win32_PhysicalMemory");
                ManagementObjectCollection MemoryCollection = MemoryClass.GetInstances();
                string memsize = null;
                string memspeed = null;
                foreach (ManagementObject MemoryObject in MemoryCollection)
                {
                    memsize = MemoryObject.Properties["Capacity"].Value.ToString() + Environment.NewLine;
                    memspeed = MemoryObject.Properties["Speed"].Value.ToString();
                    break;
                }
                string memory = "INSERT INTO memory (Size, Speed) VALUES ('" + Math.Round(System.Convert.ToDouble(memsize) / 1024 / 1024 / 1024, 2) + " ГБ" + "','" + memspeed + "')";

                ManagementClass VideoCardClass = new ManagementClass("Win32_VideoController");
                ManagementObjectCollection VideoCardCollection = VideoCardClass.GetInstances();
                string videoname = null;
                string videomemory = null;
                string videodriver = null;
                foreach (ManagementObject VideoCardObject in VideoCardCollection)
                {
                    videoname = VideoCardObject.Properties["Caption"].Value.ToString() + Environment.NewLine;
                    videomemory = VideoCardObject.Properties["AdapterRAM"].Value.ToString() + Environment.NewLine;
                    videodriver = VideoCardObject.Properties["DriverVersion"].Value.ToString();
                    break;
                }
                string videocard = "INSERT INTO videocard (Name, Memory, Driver_Version) VALUES ('" + videoname + "','" + Math.Round(System.Convert.ToDouble(videomemory) / 1024 / 1024 / 1024, 2) + " ГБ" + "', '" + videodriver + "')";

                ManagementClass DataStorageClass = new ManagementClass("Win32_PhysicalMedia");
                ManagementObjectCollection DataStorageCollection = DataStorageClass.GetInstances();
                string serialnum = null;
                foreach (ManagementObject DataStorageObject in DataStorageCollection)
                {
                    serialnum = DataStorageObject.Properties["SerialNumber"].Value.ToString() + Environment.NewLine;
                    break;
                }
                ManagementClass DataStorageClassHDD = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection DataStorageCollectionHDD = DataStorageClassHDD.GetInstances();
                string hddid = null;
                string hddver = null;
                string hddtype = null;
                string hddsize = null;
                foreach (ManagementObject DataStorageObjectHDD in DataStorageCollectionHDD)
                {
                    hddid = DataStorageObjectHDD.Properties["Model"].Value.ToString() + Environment.NewLine;
                    hddver = DataStorageObjectHDD.Properties["FirmwareRevision"].Value.ToString() + Environment.NewLine;
                    hddtype = DataStorageObjectHDD.Properties["InterfaceType"].Value.ToString() + Environment.NewLine;
                    hddsize = DataStorageObjectHDD.Properties["Size"].Value.ToString();
                    break;
                }
                ManagementClass DataStorageClassLogDisk = new ManagementClass("Win32_LogicalDisk");
                ManagementObjectCollection DataStorageCollectionLogDisk = DataStorageClassLogDisk.GetInstances();
                string logdiskname = null;
                string logdisknamegb = null;
                string logdiskfile = null;
                string logdisksize = null;
                string logdiskfree = null;
                foreach (ManagementObject DataStorageObjectLogDisk in DataStorageCollectionLogDisk)
                {
                    logdiskname = DataStorageObjectLogDisk.Properties["Caption"].Value.ToString();
                    logdisknamegb = DataStorageObjectLogDisk.Properties["VolumeName"].Value.ToString() + Environment.NewLine;
                    logdiskfile = DataStorageObjectLogDisk.Properties["FileSystem"].Value.ToString() + Environment.NewLine;
                    logdisksize = DataStorageObjectLogDisk.Properties["Size"].Value.ToString() + Environment.NewLine;
                    logdiskfree = DataStorageObjectLogDisk.Properties["FreeSpace"].Value.ToString();
                    break;
                }
                string datastorage = "INSERT INTO data_storage (Serial_Number, Model_ID, Version, Interface_Type, Size, Logical_Disk, File_System, Logical_Disk_Size, Logical_Disk_Free_Space) VALUES ('" + serialnum + "','" + hddid + "','" + hddver + "','" + hddtype + "','" + Math.Round(System.Convert.ToDouble(hddsize) / 1024 / 1024 / 1024, 2) + " ГБ" + "','" + logdiskname + " " + logdisknamegb + "','" + logdiskfile + "','" + Math.Round(System.Convert.ToDouble(logdisksize) / 1024 / 1024 / 1024, 2) + " ГБ" + "','" + Math.Round(System.Convert.ToDouble(logdiskfree) / 1024 / 1024 / 1024, 2) + " ГБ" + "')";

                ManagementClass MonitorClass = new ManagementClass("Win32_DesktopMonitor");
                ManagementObjectCollection MonitorCollection = MonitorClass.GetInstances();
                string monitorname = null;
                string monitormanufact = null;
                foreach (ManagementObject MonitorObject in MonitorCollection)
                {
                    monitorname = MonitorObject.Properties["Caption"].Value.ToString() + Environment.NewLine;
                    monitormanufact = MonitorObject.Properties["MonitorManufacturer"].Value.ToString() + Environment.NewLine;
                    break;
                }
                ManagementClass MonitorClassRate = new ManagementClass("Win32_DisplayControllerConfiguration");
                ManagementObjectCollection MonitorCollectionRate = MonitorClassRate.GetInstances();
                string monitorrate = null;
                foreach (ManagementObject MonitorObjectRate in MonitorCollectionRate)
                {
                    monitorrate = MonitorObjectRate.Properties["RefreshRate"].Value.ToString();
                    break;
                }
                ManagementClass MonitorClassResolution = new ManagementClass("Win32_VideoController");
                ManagementObjectCollection MonitorCollectionResolution = MonitorClassResolution.GetInstances();
                string monitorhorizontal = null;
                string monitorvertical = null;
                foreach (ManagementObject MonitorObjectResolution in MonitorCollectionResolution)
                {
                    monitorhorizontal = MonitorObjectResolution.Properties["CurrentHorizontalResolution"].Value.ToString();
                    monitorvertical = MonitorObjectResolution.Properties["CurrentVerticalResolution"].Value.ToString() + Environment.NewLine;
                    break;
                }
                string monitor = "INSERT INTO monitor (Name, Manufacturer, Refresh_Rate, Max_Resolution) VALUES ('" + monitorname + "','" + monitormanufact + "','" + monitorrate + " Гц" + "', '" + monitorhorizontal + "x" + monitorvertical + "')";

                ManagementClass BIOSClass = new ManagementClass("Win32_BIOS");
                ManagementObjectCollection BIOSCollection = BIOSClass.GetInstances();
                string biosdescript = null;
                string biosveros = null;
                string biosmanufact = null;
                string biosver = null;
                string biosversmmajor = null;
                string biosversmminor = null;
                foreach (ManagementObject BIOSObject in BIOSCollection)
                {
                    biosdescript = BIOSObject.Properties["Description"].Value.ToString();
                    biosveros = BIOSObject.Properties["Version"].Value.ToString() + Environment.NewLine;
                    biosmanufact = BIOSObject.Properties["Manufacturer"].Value.ToString() + Environment.NewLine;
                    biosver = BIOSObject.Properties["SMBIOSBIOSVersion"].Value.ToString() + Environment.NewLine;
                    biosversmmajor = BIOSObject.Properties["SMBIOSMajorVersion"].Value.ToString();
                    biosversmminor = BIOSObject.Properties["SMBIOSMinorVersion"].Value.ToString();
                    break;
                }
                string bios = "INSERT INTO bios (Description, Manufacturer, Version, SMBIOS_Version) VALUES ('" + biosdescript + " " + biosveros + "','" + biosmanufact + "','" + biosver + "','" + biosversmmajor + "." + biosversmminor + "')";

                MySqlCommand CommandMainInformation = new MySqlCommand(maininformation, connection);
                MySqlCommand CommandProcessor = new MySqlCommand(processor, connection);
                MySqlCommand CommandMotherboard = new MySqlCommand(motherboard, connection);
                MySqlCommand CommandMemory = new MySqlCommand(memory, connection);
                MySqlCommand CommandVideocard = new MySqlCommand(videocard, connection);
                MySqlCommand CommandDataStorage = new MySqlCommand(datastorage, connection);
                MySqlCommand CommandMonitor = new MySqlCommand(monitor, connection);
                MySqlCommand CommandBIOS = new MySqlCommand(bios, connection);
                CommandMainInformation.ExecuteNonQuery();
                CommandProcessor.ExecuteNonQuery();
                CommandMotherboard.ExecuteNonQuery();
                CommandMemory.ExecuteNonQuery();
                CommandVideocard.ExecuteNonQuery();
                CommandDataStorage.ExecuteNonQuery();
                CommandMonitor.ExecuteNonQuery();
                CommandBIOS.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
