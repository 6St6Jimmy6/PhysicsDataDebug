
namespace Physics_Data_Debug
{
    partial class FormLiveData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.liveDataMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.navigationPagesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OpenTemperaturesChart = new System.Windows.Forms.Button();
            this.to4WheelsButton = new System.Windows.Forms.Button();
            this.toGForceButton = new System.Windows.Forms.Button();
            this.toTireStaticValues = new System.Windows.Forms.Button();
            this.toSuspensionStaticValues = new System.Windows.Forms.Button();
            this.toSuspensionGeometry = new System.Windows.Forms.Button();
            this.openOfflineChartButton = new System.Windows.Forms.Button();
            this.toggleDebugWorkspaceButton = new System.Windows.Forms.Button();
            this.telemetrySidebarSplitter = new System.Windows.Forms.SplitContainer();
            this.telemetrySidebarPanel = new System.Windows.Forms.Panel();
            this.sidebarSectionsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.gameVersionSection = new System.Windows.Forms.GroupBox();
            this.gameVersionFieldsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.GameVersionComboBox = new System.Windows.Forms.ComboBox();
            this.GameConfigurationProfilesButton = new System.Windows.Forms.Button();
            this.SettingsProfilesHost = new System.Windows.Forms.Panel();
            this.versionDetectionStatus = new System.Windows.Forms.Label();
            this.sessionLoggingSection = new System.Windows.Forms.GroupBox();
            this.getProcessButton = new System.Windows.Forms.Button();
            this.startFileLoggingButton = new System.Windows.Forms.Button();
            this.toLogSettingsButton = new System.Windows.Forms.Button();
            this.toTestChartPageButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.logInterval_textBox = new System.Windows.Forms.TextBox();
            this.TickTime = new System.Windows.Forms.Label();
            this.speedTelemetrySection = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CurrentSpeed = new System.Windows.Forms.Label();
            this.accelerationTelemetrySection = new System.Windows.Forms.GroupBox();
            this.label75 = new System.Windows.Forms.Label();
            this.CurrentAcceleration = new System.Windows.Forms.Label();
            this.gforceTelemetrySection = new System.Windows.Forms.GroupBox();
            this.label74 = new System.Windows.Forms.Label();
            this.CurrentGForce = new System.Windows.Forms.Label();
            this.aeroTelemetrySection = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CurrentXDrag = new System.Windows.Forms.Label();
            this.CurrentYDrag = new System.Windows.Forms.Label();
            this.CurrentZDrag = new System.Windows.Forms.Label();
            this.CurrentTotalDrag = new System.Windows.Forms.Label();
            this.liftTelemetrySection = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.CurrentFrontLift = new System.Windows.Forms.Label();
            this.CurrentRearLift = new System.Windows.Forms.Label();
            this.engineTelemetrySection = new System.Windows.Forms.GroupBox();
            this.label78 = new System.Windows.Forms.Label();
            this.CurrentEngineRPM = new System.Windows.Forms.Label();
            this.CurrentEngineRPMAxle = new System.Windows.Forms.Label();
            this.CurrentEngineTorque = new System.Windows.Forms.Label();
            this.CurrentEnginePower = new System.Windows.Forms.Label();
            this.differentialTelemetrySection = new System.Windows.Forms.GroupBox();
            this.Differential = new System.Windows.Forms.Label();
            this.differentialLeftSection = new System.Windows.Forms.GroupBox();
            this.LeftLabel = new System.Windows.Forms.Label();
            this.CurrentLeftDifferentialOpen = new System.Windows.Forms.Label();
            this.CurrentLeftDifferentialSpeedRad = new System.Windows.Forms.Label();
            this.CurrentLeftDifferentialTorque = new System.Windows.Forms.Label();
            this.differentialRightSection = new System.Windows.Forms.GroupBox();
            this.RightLabel = new System.Windows.Forms.Label();
            this.CurrentRightDifferentialOpen = new System.Windows.Forms.Label();
            this.CurrentRightDifferentialSpeedRad = new System.Windows.Forms.Label();
            this.CurrentRightDifferentialTorque = new System.Windows.Forms.Label();
            this.debugWorkspaceSplitter = new System.Windows.Forms.SplitContainer();
            this.wheelTelemetryColumn = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.fourWheelScrollPanel = new System.Windows.Forms.Panel();
            this.fourWheelGrid = new System.Windows.Forms.TableLayoutPanel();
            this.panel1TelemetryCard = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1TelemetryRow0 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_FL_TravelSpeed = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label_FL_AngularVelocity = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label_FL_VerticalLoad = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label_FL_Deflection = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label_FL_LoadedRadius = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label_FL_EffectiveRadius = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label_FL_ContactLength = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label_FL_CurrentContactBrakeTorque = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label_FL_MaxCurrentContactBrakeTorque = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label_FL_LateralLoad = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label_FL_LongitudinalLoad = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow7 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label_FL_SlipAngleDeg = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label_FL_SlipRatio = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow8 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label_FL_LateralFriction = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label_FL_LongitudinalFriction = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow9 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label_FL_LateralSlipSpeed = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label_FL_LongitudinalSlipSpeed = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow10 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label_FL_TreadTemperature = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label_FL_InnerTemperature = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow11 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label_FL_TotalFriction = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label_FL_TotalFrictionAngle = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow12 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.label_FL_SuspensionLength = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label_FL_SuspensionVelocity = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow13 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label_FL_TireSteerAngle = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label_FL_CamberAngle = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.panel1TelemetryRow14 = new System.Windows.Forms.Panel();
            this.label188 = new System.Windows.Forms.Label();
            this.label_FL_Mx = new System.Windows.Forms.Label();
            this.label189 = new System.Windows.Forms.Label();
            this.label_FL_Mz = new System.Windows.Forms.Label();
            this.label190 = new System.Windows.Forms.Label();
            this.label_FL_My = new System.Windows.Forms.Label();
            this.panel1TelemetryRow15 = new System.Windows.Forms.Panel();
            this.label191 = new System.Windows.Forms.Label();
            this.label_FL_PneumaticTrail = new System.Windows.Forms.Label();
            this.label193 = new System.Windows.Forms.Label();
            this.label_FL_RollingResistance = new System.Windows.Forms.Label();
            this.panel2TelemetryCard = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2TelemetryRow0 = new System.Windows.Forms.Panel();
            this.label117 = new System.Windows.Forms.Label();
            this.label_FR_TravelSpeed = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow1 = new System.Windows.Forms.Panel();
            this.label116 = new System.Windows.Forms.Label();
            this.label_FR_AngularVelocity = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow2 = new System.Windows.Forms.Panel();
            this.label115 = new System.Windows.Forms.Label();
            this.label_FR_VerticalLoad = new System.Windows.Forms.Label();
            this.label174 = new System.Windows.Forms.Label();
            this.label_FR_Deflection = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow3 = new System.Windows.Forms.Panel();
            this.label114 = new System.Windows.Forms.Label();
            this.label_FR_LoadedRadius = new System.Windows.Forms.Label();
            this.label175 = new System.Windows.Forms.Label();
            this.label_FR_EffectiveRadius = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow4 = new System.Windows.Forms.Panel();
            this.label113 = new System.Windows.Forms.Label();
            this.label_FR_ContactLength = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow5 = new System.Windows.Forms.Panel();
            this.label112 = new System.Windows.Forms.Label();
            this.label_FR_CurrentContactBrakeTorque = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.label_FR_MaxCurrentContactBrakeTorque = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow6 = new System.Windows.Forms.Panel();
            this.label110 = new System.Windows.Forms.Label();
            this.label_FR_LateralLoad = new System.Windows.Forms.Label();
            this.label177 = new System.Windows.Forms.Label();
            this.label_FR_LongitudinalLoad = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow7 = new System.Windows.Forms.Panel();
            this.label109 = new System.Windows.Forms.Label();
            this.label_FR_SlipAngleDeg = new System.Windows.Forms.Label();
            this.label178 = new System.Windows.Forms.Label();
            this.label_FR_SlipRatio = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow8 = new System.Windows.Forms.Panel();
            this.label108 = new System.Windows.Forms.Label();
            this.label_FR_LateralFriction = new System.Windows.Forms.Label();
            this.label179 = new System.Windows.Forms.Label();
            this.label_FR_LongitudinalFriction = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow9 = new System.Windows.Forms.Panel();
            this.label107 = new System.Windows.Forms.Label();
            this.label_FR_LateralSlipSpeed = new System.Windows.Forms.Label();
            this.label180 = new System.Windows.Forms.Label();
            this.label_FR_LongitudinalSlipSpeed = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow10 = new System.Windows.Forms.Panel();
            this.label106 = new System.Windows.Forms.Label();
            this.label_FR_TreadTemperature = new System.Windows.Forms.Label();
            this.label181 = new System.Windows.Forms.Label();
            this.label_FR_InnerTemperature = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow11 = new System.Windows.Forms.Panel();
            this.label105 = new System.Windows.Forms.Label();
            this.label_FR_TotalFriction = new System.Windows.Forms.Label();
            this.label182 = new System.Windows.Forms.Label();
            this.label_FR_TotalFrictionAngle = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow12 = new System.Windows.Forms.Panel();
            this.label104 = new System.Windows.Forms.Label();
            this.label_FR_SuspensionLength = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.label_FR_SuspensionVelocity = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow13 = new System.Windows.Forms.Panel();
            this.label111 = new System.Windows.Forms.Label();
            this.label_FR_TireSteerAngle = new System.Windows.Forms.Label();
            this.label184 = new System.Windows.Forms.Label();
            this.label_FR_CamberAngle = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.panel2TelemetryRow14 = new System.Windows.Forms.Panel();
            this.label187 = new System.Windows.Forms.Label();
            this.label_FR_Mx = new System.Windows.Forms.Label();
            this.label186 = new System.Windows.Forms.Label();
            this.label_FR_Mz = new System.Windows.Forms.Label();
            this.label185 = new System.Windows.Forms.Label();
            this.label_FR_My = new System.Windows.Forms.Label();
            this.panel2TelemetryRow15 = new System.Windows.Forms.Panel();
            this.label198 = new System.Windows.Forms.Label();
            this.label_FR_PneumaticTrail = new System.Windows.Forms.Label();
            this.label192 = new System.Windows.Forms.Label();
            this.label_FR_RollingResistance = new System.Windows.Forms.Label();
            this.panel3TelemetryCard = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel3TelemetryRow0 = new System.Windows.Forms.Panel();
            this.label131 = new System.Windows.Forms.Label();
            this.label_RL_TravelSpeed = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow1 = new System.Windows.Forms.Panel();
            this.label130 = new System.Windows.Forms.Label();
            this.label_RL_AngularVelocity = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow2 = new System.Windows.Forms.Panel();
            this.label129 = new System.Windows.Forms.Label();
            this.label_RL_VerticalLoad = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label_RL_Deflection = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow3 = new System.Windows.Forms.Panel();
            this.label128 = new System.Windows.Forms.Label();
            this.label_RL_LoadedRadius = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label_RL_EffectiveRadius = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow4 = new System.Windows.Forms.Panel();
            this.label127 = new System.Windows.Forms.Label();
            this.label_RL_ContactLength = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow5 = new System.Windows.Forms.Panel();
            this.label126 = new System.Windows.Forms.Label();
            this.label_RL_CurrentContactBrakeTorque = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label_RL_MaxCurrentContactBrakeTorque = new System.Windows.Forms.Label();
            this.label154 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow6 = new System.Windows.Forms.Panel();
            this.label124 = new System.Windows.Forms.Label();
            this.label_RL_LateralLoad = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label_RL_LongitudinalLoad = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow7 = new System.Windows.Forms.Panel();
            this.label123 = new System.Windows.Forms.Label();
            this.label_RL_SlipAngleDeg = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label_RL_SlipRatio = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow8 = new System.Windows.Forms.Panel();
            this.label122 = new System.Windows.Forms.Label();
            this.label_RL_LateralFriction = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label_RL_LongitudinalFriction = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow9 = new System.Windows.Forms.Panel();
            this.label121 = new System.Windows.Forms.Label();
            this.label_RL_LateralSlipSpeed = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label_RL_LongitudinalSlipSpeed = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow10 = new System.Windows.Forms.Panel();
            this.label120 = new System.Windows.Forms.Label();
            this.label_RL_TreadTemperature = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label_RL_InnerTemperature = new System.Windows.Forms.Label();
            this.label149 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow11 = new System.Windows.Forms.Panel();
            this.label119 = new System.Windows.Forms.Label();
            this.label_RL_TotalFriction = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label_RL_TotalFrictionAngle = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow12 = new System.Windows.Forms.Panel();
            this.label118 = new System.Windows.Forms.Label();
            this.label_RL_SuspensionLength = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label_RL_SuspensionVelocity = new System.Windows.Forms.Label();
            this.label147 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow13 = new System.Windows.Forms.Panel();
            this.label125 = new System.Windows.Forms.Label();
            this.label_RL_TireSteerAngle = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label_RL_CamberAngle = new System.Windows.Forms.Label();
            this.label146 = new System.Windows.Forms.Label();
            this.panel3TelemetryRow14 = new System.Windows.Forms.Panel();
            this.label196 = new System.Windows.Forms.Label();
            this.label_RL_Mx = new System.Windows.Forms.Label();
            this.label195 = new System.Windows.Forms.Label();
            this.label_RL_Mz = new System.Windows.Forms.Label();
            this.label194 = new System.Windows.Forms.Label();
            this.label_RL_My = new System.Windows.Forms.Label();
            this.panel3TelemetryRow15 = new System.Windows.Forms.Panel();
            this.label204 = new System.Windows.Forms.Label();
            this.label_RL_PneumaticTrail = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.label_RL_RollingResistance = new System.Windows.Forms.Label();
            this.panel4TelemetryCard = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel4TelemetryRow0 = new System.Windows.Forms.Panel();
            this.label144 = new System.Windows.Forms.Label();
            this.label_RR_TravelSpeed = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow1 = new System.Windows.Forms.Panel();
            this.label145 = new System.Windows.Forms.Label();
            this.label_RR_AngularVelocity = new System.Windows.Forms.Label();
            this.label172 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow2 = new System.Windows.Forms.Panel();
            this.label143 = new System.Windows.Forms.Label();
            this.label_RR_VerticalLoad = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label_RR_Deflection = new System.Windows.Forms.Label();
            this.label171 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow3 = new System.Windows.Forms.Panel();
            this.label142 = new System.Windows.Forms.Label();
            this.label_RR_LoadedRadius = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label_RR_EffectiveRadius = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow4 = new System.Windows.Forms.Panel();
            this.label141 = new System.Windows.Forms.Label();
            this.label_RR_ContactLength = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow5 = new System.Windows.Forms.Panel();
            this.label140 = new System.Windows.Forms.Label();
            this.label_RR_CurrentContactBrakeTorque = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label_RR_MaxCurrentContactBrakeTorque = new System.Windows.Forms.Label();
            this.label168 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow6 = new System.Windows.Forms.Panel();
            this.label138 = new System.Windows.Forms.Label();
            this.label_RR_LateralLoad = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label_RR_LongitudinalLoad = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow7 = new System.Windows.Forms.Panel();
            this.label137 = new System.Windows.Forms.Label();
            this.label_RR_SlipAngleDeg = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label_RR_SlipRatio = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow8 = new System.Windows.Forms.Panel();
            this.label136 = new System.Windows.Forms.Label();
            this.label_RR_LateralFriction = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label_RR_LongitudinalFriction = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow9 = new System.Windows.Forms.Panel();
            this.label135 = new System.Windows.Forms.Label();
            this.label_RR_LateralSlipSpeed = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label_RR_LongitudinalSlipSpeed = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow10 = new System.Windows.Forms.Panel();
            this.label134 = new System.Windows.Forms.Label();
            this.label_RR_TreadTemperature = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label_RR_InnerTemperature = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow11 = new System.Windows.Forms.Panel();
            this.label133 = new System.Windows.Forms.Label();
            this.label_RR_TotalFriction = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label_RR_TotalFrictionAngle = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow12 = new System.Windows.Forms.Panel();
            this.label132 = new System.Windows.Forms.Label();
            this.label_RR_SuspensionLength = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label_RR_SuspensionVelocity = new System.Windows.Forms.Label();
            this.label161 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow13 = new System.Windows.Forms.Panel();
            this.label139 = new System.Windows.Forms.Label();
            this.label_RR_TireSteerAngle = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label_RR_CamberAngle = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.panel4TelemetryRow14 = new System.Windows.Forms.Panel();
            this.label202 = new System.Windows.Forms.Label();
            this.label_RR_Mx = new System.Windows.Forms.Label();
            this.label201 = new System.Windows.Forms.Label();
            this.label_RR_Mz = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.label_RR_My = new System.Windows.Forms.Label();
            this.panel4TelemetryRow15 = new System.Windows.Forms.Panel();
            this.label207 = new System.Windows.Forms.Label();
            this.label_RR_PneumaticTrail = new System.Windows.Forms.Label();
            this.label205 = new System.Windows.Forms.Label();
            this.label_RR_RollingResistance = new System.Windows.Forms.Label();
            this.debugWorkspacePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.debug1Section = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.debug2Section = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.debug3Section = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.debug4Section = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.debug5Section = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.debug6Section = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonUpdates = new System.Windows.Forms.Timer(this.components);
            this.label38 = new System.Windows.Forms.Label();
            this.liveDataMainLayout.SuspendLayout();
            this.navigationPagesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.telemetrySidebarSplitter)).BeginInit();
            this.telemetrySidebarSplitter.Panel1.SuspendLayout();
            this.telemetrySidebarSplitter.Panel2.SuspendLayout();
            this.telemetrySidebarSplitter.SuspendLayout();
            this.telemetrySidebarPanel.SuspendLayout();
            this.sidebarSectionsLayout.SuspendLayout();
            this.gameVersionSection.SuspendLayout();
            this.gameVersionFieldsLayout.SuspendLayout();
            this.sessionLoggingSection.SuspendLayout();
            this.speedTelemetrySection.SuspendLayout();
            this.accelerationTelemetrySection.SuspendLayout();
            this.gforceTelemetrySection.SuspendLayout();
            this.aeroTelemetrySection.SuspendLayout();
            this.liftTelemetrySection.SuspendLayout();
            this.engineTelemetrySection.SuspendLayout();
            this.differentialTelemetrySection.SuspendLayout();
            this.differentialLeftSection.SuspendLayout();
            this.differentialRightSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debugWorkspaceSplitter)).BeginInit();
            this.debugWorkspaceSplitter.Panel1.SuspendLayout();
            this.debugWorkspaceSplitter.Panel2.SuspendLayout();
            this.debugWorkspaceSplitter.SuspendLayout();
            this.wheelTelemetryColumn.SuspendLayout();
            this.fourWheelScrollPanel.SuspendLayout();
            this.fourWheelGrid.SuspendLayout();
            this.panel1TelemetryCard.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel1TelemetryRow0.SuspendLayout();
            this.panel1TelemetryRow1.SuspendLayout();
            this.panel1TelemetryRow2.SuspendLayout();
            this.panel1TelemetryRow3.SuspendLayout();
            this.panel1TelemetryRow4.SuspendLayout();
            this.panel1TelemetryRow5.SuspendLayout();
            this.panel1TelemetryRow6.SuspendLayout();
            this.panel1TelemetryRow7.SuspendLayout();
            this.panel1TelemetryRow8.SuspendLayout();
            this.panel1TelemetryRow9.SuspendLayout();
            this.panel1TelemetryRow10.SuspendLayout();
            this.panel1TelemetryRow11.SuspendLayout();
            this.panel1TelemetryRow12.SuspendLayout();
            this.panel1TelemetryRow13.SuspendLayout();
            this.panel1TelemetryRow14.SuspendLayout();
            this.panel1TelemetryRow15.SuspendLayout();
            this.panel2TelemetryCard.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel2TelemetryRow0.SuspendLayout();
            this.panel2TelemetryRow1.SuspendLayout();
            this.panel2TelemetryRow2.SuspendLayout();
            this.panel2TelemetryRow3.SuspendLayout();
            this.panel2TelemetryRow4.SuspendLayout();
            this.panel2TelemetryRow5.SuspendLayout();
            this.panel2TelemetryRow6.SuspendLayout();
            this.panel2TelemetryRow7.SuspendLayout();
            this.panel2TelemetryRow8.SuspendLayout();
            this.panel2TelemetryRow9.SuspendLayout();
            this.panel2TelemetryRow10.SuspendLayout();
            this.panel2TelemetryRow11.SuspendLayout();
            this.panel2TelemetryRow12.SuspendLayout();
            this.panel2TelemetryRow13.SuspendLayout();
            this.panel2TelemetryRow14.SuspendLayout();
            this.panel2TelemetryRow15.SuspendLayout();
            this.panel3TelemetryCard.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel3TelemetryRow0.SuspendLayout();
            this.panel3TelemetryRow1.SuspendLayout();
            this.panel3TelemetryRow2.SuspendLayout();
            this.panel3TelemetryRow3.SuspendLayout();
            this.panel3TelemetryRow4.SuspendLayout();
            this.panel3TelemetryRow5.SuspendLayout();
            this.panel3TelemetryRow6.SuspendLayout();
            this.panel3TelemetryRow7.SuspendLayout();
            this.panel3TelemetryRow8.SuspendLayout();
            this.panel3TelemetryRow9.SuspendLayout();
            this.panel3TelemetryRow10.SuspendLayout();
            this.panel3TelemetryRow11.SuspendLayout();
            this.panel3TelemetryRow12.SuspendLayout();
            this.panel3TelemetryRow13.SuspendLayout();
            this.panel3TelemetryRow14.SuspendLayout();
            this.panel3TelemetryRow15.SuspendLayout();
            this.panel4TelemetryCard.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel4TelemetryRow0.SuspendLayout();
            this.panel4TelemetryRow1.SuspendLayout();
            this.panel4TelemetryRow2.SuspendLayout();
            this.panel4TelemetryRow3.SuspendLayout();
            this.panel4TelemetryRow4.SuspendLayout();
            this.panel4TelemetryRow5.SuspendLayout();
            this.panel4TelemetryRow6.SuspendLayout();
            this.panel4TelemetryRow7.SuspendLayout();
            this.panel4TelemetryRow8.SuspendLayout();
            this.panel4TelemetryRow9.SuspendLayout();
            this.panel4TelemetryRow10.SuspendLayout();
            this.panel4TelemetryRow11.SuspendLayout();
            this.panel4TelemetryRow12.SuspendLayout();
            this.panel4TelemetryRow13.SuspendLayout();
            this.panel4TelemetryRow14.SuspendLayout();
            this.panel4TelemetryRow15.SuspendLayout();
            this.debugWorkspacePanel.SuspendLayout();
            this.debug1Section.SuspendLayout();
            this.debug2Section.SuspendLayout();
            this.debug3Section.SuspendLayout();
            this.debug4Section.SuspendLayout();
            this.debug5Section.SuspendLayout();
            this.debug6Section.SuspendLayout();
            this.SuspendLayout();
            // 
            // liveDataMainLayout
            // 
            this.liveDataMainLayout.BackColor = System.Drawing.Color.Black;
            this.liveDataMainLayout.ColumnCount = 1;
            this.liveDataMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.liveDataMainLayout.Controls.Add(this.navigationPagesPanel, 0, 0);
            this.liveDataMainLayout.Controls.Add(this.telemetrySidebarSplitter, 0, 1);
            this.liveDataMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liveDataMainLayout.Location = new System.Drawing.Point(0, 0);
            this.liveDataMainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.liveDataMainLayout.Name = "liveDataMainLayout";
            this.liveDataMainLayout.RowCount = 2;
            this.liveDataMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.liveDataMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.liveDataMainLayout.Size = new System.Drawing.Size(1871, 1439);
            this.liveDataMainLayout.TabIndex = 0;
            // 
            // navigationPagesPanel
            // 
            this.navigationPagesPanel.AutoScroll = true;
            this.navigationPagesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.navigationPagesPanel.Controls.Add(this.OpenTemperaturesChart);
            this.navigationPagesPanel.Controls.Add(this.to4WheelsButton);
            this.navigationPagesPanel.Controls.Add(this.toGForceButton);
            this.navigationPagesPanel.Controls.Add(this.toTireStaticValues);
            this.navigationPagesPanel.Controls.Add(this.toSuspensionStaticValues);
            this.navigationPagesPanel.Controls.Add(this.toSuspensionGeometry);
            this.navigationPagesPanel.Controls.Add(this.openOfflineChartButton);
            this.navigationPagesPanel.Controls.Add(this.toggleDebugWorkspaceButton);
            this.navigationPagesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPagesPanel.Location = new System.Drawing.Point(3, 3);
            this.navigationPagesPanel.Name = "navigationPagesPanel";
            this.navigationPagesPanel.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.navigationPagesPanel.Size = new System.Drawing.Size(1865, 59);
            this.navigationPagesPanel.TabIndex = 0;
            this.navigationPagesPanel.WrapContents = false;
            // 
            // OpenTemperaturesChart
            // 
            this.OpenTemperaturesChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OpenTemperaturesChart.ForeColor = System.Drawing.Color.White;
            this.OpenTemperaturesChart.Location = new System.Drawing.Point(13, 10);
            this.OpenTemperaturesChart.Margin = new System.Windows.Forms.Padding(5);
            this.OpenTemperaturesChart.Name = "OpenTemperaturesChart";
            this.OpenTemperaturesChart.Size = new System.Drawing.Size(120, 40);
            this.OpenTemperaturesChart.TabIndex = 240;
            this.OpenTemperaturesChart.Text = "Live Time Chart";
            this.OpenTemperaturesChart.UseVisualStyleBackColor = false;
            this.OpenTemperaturesChart.Click += new System.EventHandler(this.OpenTemperaturesChart_Click);
            // 
            // to4WheelsButton
            // 
            this.to4WheelsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.to4WheelsButton.ForeColor = System.Drawing.Color.White;
            this.to4WheelsButton.Location = new System.Drawing.Point(143, 10);
            this.to4WheelsButton.Margin = new System.Windows.Forms.Padding(5);
            this.to4WheelsButton.Name = "to4WheelsButton";
            this.to4WheelsButton.Size = new System.Drawing.Size(120, 40);
            this.to4WheelsButton.TabIndex = 275;
            this.to4WheelsButton.Text = "Four Wheels Page";
            this.to4WheelsButton.UseVisualStyleBackColor = false;
            this.to4WheelsButton.Click += new System.EventHandler(this.to4WheelsButton_Click);
            // 
            // toGForceButton
            // 
            this.toGForceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toGForceButton.ForeColor = System.Drawing.Color.White;
            this.toGForceButton.Location = new System.Drawing.Point(273, 10);
            this.toGForceButton.Margin = new System.Windows.Forms.Padding(5);
            this.toGForceButton.Name = "toGForceButton";
            this.toGForceButton.Size = new System.Drawing.Size(120, 40);
            this.toGForceButton.TabIndex = 273;
            this.toGForceButton.Text = "G-Force Page";
            this.toGForceButton.UseVisualStyleBackColor = false;
            this.toGForceButton.Click += new System.EventHandler(this.toGForceButton_Click);
            // 
            // toTireStaticValues
            // 
            this.toTireStaticValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toTireStaticValues.ForeColor = System.Drawing.Color.White;
            this.toTireStaticValues.Location = new System.Drawing.Point(403, 10);
            this.toTireStaticValues.Margin = new System.Windows.Forms.Padding(5);
            this.toTireStaticValues.Name = "toTireStaticValues";
            this.toTireStaticValues.Size = new System.Drawing.Size(120, 40);
            this.toTireStaticValues.TabIndex = 155;
            this.toTireStaticValues.Text = "Tire Static Values Page";
            this.toTireStaticValues.UseVisualStyleBackColor = false;
            this.toTireStaticValues.Click += new System.EventHandler(this.toTireStaticValues_Click);
            // 
            // toSuspensionStaticValues
            // 
            this.toSuspensionStaticValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toSuspensionStaticValues.ForeColor = System.Drawing.Color.White;
            this.toSuspensionStaticValues.Location = new System.Drawing.Point(533, 10);
            this.toSuspensionStaticValues.Margin = new System.Windows.Forms.Padding(5);
            this.toSuspensionStaticValues.Name = "toSuspensionStaticValues";
            this.toSuspensionStaticValues.Size = new System.Drawing.Size(120, 40);
            this.toSuspensionStaticValues.TabIndex = 239;
            this.toSuspensionStaticValues.Text = "Suspension Static Values Page";
            this.toSuspensionStaticValues.UseVisualStyleBackColor = false;
            this.toSuspensionStaticValues.Click += new System.EventHandler(this.toSuspensionStaticValuesButton_Click);
            // 
            // toSuspensionGeometry
            // 
            this.toSuspensionGeometry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toSuspensionGeometry.ForeColor = System.Drawing.Color.White;
            this.toSuspensionGeometry.Location = new System.Drawing.Point(663, 10);
            this.toSuspensionGeometry.Margin = new System.Windows.Forms.Padding(5);
            this.toSuspensionGeometry.Name = "toSuspensionGeometry";
            this.toSuspensionGeometry.Size = new System.Drawing.Size(120, 40);
            this.toSuspensionGeometry.TabIndex = 287;
            this.toSuspensionGeometry.Text = "Suspension Geometry Page";
            this.toSuspensionGeometry.UseVisualStyleBackColor = false;
            this.toSuspensionGeometry.Click += new System.EventHandler(this.toSuspensionGeometryOpen_Click);
            // 
            // openOfflineChartButton
            // 
            this.openOfflineChartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.openOfflineChartButton.ForeColor = System.Drawing.Color.White;
            this.openOfflineChartButton.Location = new System.Drawing.Point(793, 10);
            this.openOfflineChartButton.Margin = new System.Windows.Forms.Padding(5);
            this.openOfflineChartButton.Name = "openOfflineChartButton";
            this.openOfflineChartButton.Size = new System.Drawing.Size(120, 40);
            this.openOfflineChartButton.TabIndex = 288;
            this.openOfflineChartButton.Text = "Offline CSV Chart";
            this.openOfflineChartButton.UseVisualStyleBackColor = false;
            // 
            // toggleDebugWorkspaceButton
            // 
            this.toggleDebugWorkspaceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toggleDebugWorkspaceButton.ForeColor = System.Drawing.Color.White;
            this.toggleDebugWorkspaceButton.Location = new System.Drawing.Point(923, 10);
            this.toggleDebugWorkspaceButton.Margin = new System.Windows.Forms.Padding(5);
            this.toggleDebugWorkspaceButton.Name = "toggleDebugWorkspaceButton";
            this.toggleDebugWorkspaceButton.Size = new System.Drawing.Size(120, 40);
            this.toggleDebugWorkspaceButton.TabIndex = 289;
            this.toggleDebugWorkspaceButton.Text = "Hide debug output";
            this.toggleDebugWorkspaceButton.UseVisualStyleBackColor = false;
            // 
            // telemetrySidebarSplitter
            // 
            this.telemetrySidebarSplitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.telemetrySidebarSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telemetrySidebarSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.telemetrySidebarSplitter.Location = new System.Drawing.Point(3, 68);
            this.telemetrySidebarSplitter.Name = "telemetrySidebarSplitter";
            // 
            // telemetrySidebarSplitter.Panel1
            // 
            this.telemetrySidebarSplitter.Panel1.Controls.Add(this.telemetrySidebarPanel);
            this.telemetrySidebarSplitter.Panel1MinSize = 170;
            // 
            // telemetrySidebarSplitter.Panel2
            // 
            this.telemetrySidebarSplitter.Panel2.Controls.Add(this.debugWorkspaceSplitter);
            this.telemetrySidebarSplitter.Panel2MinSize = 300;
            this.telemetrySidebarSplitter.Size = new System.Drawing.Size(1865, 1368);
            this.telemetrySidebarSplitter.SplitterDistance = 170;
            this.telemetrySidebarSplitter.SplitterWidth = 6;
            this.telemetrySidebarSplitter.TabIndex = 1;
            // 
            // telemetrySidebarPanel
            // 
            this.telemetrySidebarPanel.AutoScroll = true;
            this.telemetrySidebarPanel.BackColor = System.Drawing.Color.Black;
            this.telemetrySidebarPanel.Controls.Add(this.sidebarSectionsLayout);
            this.telemetrySidebarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telemetrySidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.telemetrySidebarPanel.Name = "telemetrySidebarPanel";
            this.telemetrySidebarPanel.Padding = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.telemetrySidebarPanel.Size = new System.Drawing.Size(170, 1368);
            this.telemetrySidebarPanel.TabIndex = 0;
            // 
            // sidebarSectionsLayout
            // 
            this.sidebarSectionsLayout.AutoSize = true;
            this.sidebarSectionsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sidebarSectionsLayout.ColumnCount = 1;
            this.sidebarSectionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sidebarSectionsLayout.Controls.Add(this.gameVersionSection, 0, 0);
            this.sidebarSectionsLayout.Controls.Add(this.sessionLoggingSection, 0, 1);
            this.sidebarSectionsLayout.Controls.Add(this.speedTelemetrySection, 0, 2);
            this.sidebarSectionsLayout.Controls.Add(this.accelerationTelemetrySection, 0, 3);
            this.sidebarSectionsLayout.Controls.Add(this.gforceTelemetrySection, 0, 4);
            this.sidebarSectionsLayout.Controls.Add(this.aeroTelemetrySection, 0, 5);
            this.sidebarSectionsLayout.Controls.Add(this.liftTelemetrySection, 0, 6);
            this.sidebarSectionsLayout.Controls.Add(this.engineTelemetrySection, 0, 7);
            this.sidebarSectionsLayout.Controls.Add(this.differentialTelemetrySection, 0, 8);
            this.sidebarSectionsLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.sidebarSectionsLayout.Location = new System.Drawing.Point(6, 8);
            this.sidebarSectionsLayout.Margin = new System.Windows.Forms.Padding(0);
            this.sidebarSectionsLayout.Name = "sidebarSectionsLayout";
            this.sidebarSectionsLayout.RowCount = 9;
            this.sidebarSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.sidebarSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.sidebarSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.sidebarSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.sidebarSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.sidebarSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.sidebarSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.sidebarSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.sidebarSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.sidebarSectionsLayout.Size = new System.Drawing.Size(158, 1195);
            this.sidebarSectionsLayout.TabIndex = 0;
            // 
            // gameVersionSection
            // 
            this.gameVersionSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.gameVersionSection.Controls.Add(this.gameVersionFieldsLayout);
            this.gameVersionSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameVersionSection.ForeColor = System.Drawing.Color.White;
            this.gameVersionSection.Location = new System.Drawing.Point(0, 0);
            this.gameVersionSection.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.gameVersionSection.Name = "gameVersionSection";
            this.gameVersionSection.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.gameVersionSection.Size = new System.Drawing.Size(158, 172);
            this.gameVersionSection.TabIndex = 0;
            this.gameVersionSection.TabStop = false;
            this.gameVersionSection.Text = "Select Game Version";
            // 
            // gameVersionFieldsLayout
            // 
            this.gameVersionFieldsLayout.BackColor = System.Drawing.Color.Transparent;
            this.gameVersionFieldsLayout.ColumnCount = 1;
            this.gameVersionFieldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gameVersionFieldsLayout.Controls.Add(this.GameVersionComboBox, 0, 0);
            this.gameVersionFieldsLayout.Controls.Add(this.GameConfigurationProfilesButton, 0, 1);
            this.gameVersionFieldsLayout.Controls.Add(this.SettingsProfilesHost, 0, 2);
            this.gameVersionFieldsLayout.Controls.Add(this.versionDetectionStatus, 0, 3);
            this.gameVersionFieldsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameVersionFieldsLayout.Location = new System.Drawing.Point(9, 24);
            this.gameVersionFieldsLayout.Margin = new System.Windows.Forms.Padding(0);
            this.gameVersionFieldsLayout.Name = "gameVersionFieldsLayout";
            this.gameVersionFieldsLayout.Padding = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.gameVersionFieldsLayout.RowCount = 4;
            this.gameVersionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.gameVersionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.gameVersionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.gameVersionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gameVersionFieldsLayout.Size = new System.Drawing.Size(140, 148);
            this.gameVersionFieldsLayout.TabIndex = 0;
            // 
            // GameVersionComboBox
            // 
            this.GameVersionComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameVersionComboBox.FormattingEnabled = true;
            this.GameVersionComboBox.Location = new System.Drawing.Point(3, 10);
            this.GameVersionComboBox.Margin = new System.Windows.Forms.Padding(0, 6, 0, 4);
            this.GameVersionComboBox.Name = "GameVersionComboBox";
            this.GameVersionComboBox.Size = new System.Drawing.Size(134, 33);
            this.GameVersionComboBox.TabIndex = 285;
            this.GameVersionComboBox.SelectionChangeCommitted += new System.EventHandler(this.GameVersionComboBox_SelectionChangeCommitted);
            // 
            // GameConfigurationProfilesButton
            // 
            this.GameConfigurationProfilesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GameConfigurationProfilesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameConfigurationProfilesButton.ForeColor = System.Drawing.Color.White;
            this.GameConfigurationProfilesButton.Location = new System.Drawing.Point(3, 48);
            this.GameConfigurationProfilesButton.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.GameConfigurationProfilesButton.Name = "GameConfigurationProfilesButton";
            this.GameConfigurationProfilesButton.Size = new System.Drawing.Size(134, 32);
            this.GameConfigurationProfilesButton.TabIndex = 286;
            this.GameConfigurationProfilesButton.Text = "Config ▼";
            this.GameConfigurationProfilesButton.UseVisualStyleBackColor = false;
            // 
            // SettingsProfilesHost
            // 
            this.SettingsProfilesHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsProfilesHost.Location = new System.Drawing.Point(3, 86);
            this.SettingsProfilesHost.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.SettingsProfilesHost.Name = "SettingsProfilesHost";
            this.SettingsProfilesHost.Size = new System.Drawing.Size(134, 36);
            this.SettingsProfilesHost.TabIndex = 287;
            // 
            // versionDetectionStatus
            // 
            this.versionDetectionStatus.BackColor = System.Drawing.Color.Transparent;
            this.versionDetectionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionDetectionStatus.ForeColor = System.Drawing.Color.White;
            this.versionDetectionStatus.Location = new System.Drawing.Point(3, 128);
            this.versionDetectionStatus.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.versionDetectionStatus.Name = "versionDetectionStatus";
            this.versionDetectionStatus.Size = new System.Drawing.Size(134, 18);
            this.versionDetectionStatus.TabIndex = 288;
            this.versionDetectionStatus.Text = "Auto: detection on Get Process";
            // 
            // sessionLoggingSection
            // 
            this.sessionLoggingSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.sessionLoggingSection.Controls.Add(this.getProcessButton);
            this.sessionLoggingSection.Controls.Add(this.startFileLoggingButton);
            this.sessionLoggingSection.Controls.Add(this.toLogSettingsButton);
            this.sessionLoggingSection.Controls.Add(this.toTestChartPageButton);
            this.sessionLoggingSection.Controls.Add(this.label15);
            this.sessionLoggingSection.Controls.Add(this.logInterval_textBox);
            this.sessionLoggingSection.Controls.Add(this.TickTime);
            this.sessionLoggingSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionLoggingSection.ForeColor = System.Drawing.Color.White;
            this.sessionLoggingSection.Location = new System.Drawing.Point(0, 180);
            this.sessionLoggingSection.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.sessionLoggingSection.Name = "sessionLoggingSection";
            this.sessionLoggingSection.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.sessionLoggingSection.Size = new System.Drawing.Size(158, 242);
            this.sessionLoggingSection.TabIndex = 1;
            this.sessionLoggingSection.TabStop = false;
            this.sessionLoggingSection.Text = "Session and logging";
            // 
            // getProcessButton
            // 
            this.getProcessButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.getProcessButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.getProcessButton.ForeColor = System.Drawing.Color.White;
            this.getProcessButton.Location = new System.Drawing.Point(10, 17);
            this.getProcessButton.Margin = new System.Windows.Forms.Padding(6);
            this.getProcessButton.Name = "getProcessButton";
            this.getProcessButton.Size = new System.Drawing.Size(137, 40);
            this.getProcessButton.TabIndex = 257;
            this.getProcessButton.Text = "Get Process";
            this.getProcessButton.UseVisualStyleBackColor = false;
            this.getProcessButton.Click += new System.EventHandler(this.getProcessButton_Click);
            // 
            // startFileLoggingButton
            // 
            this.startFileLoggingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startFileLoggingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.startFileLoggingButton.ForeColor = System.Drawing.Color.White;
            this.startFileLoggingButton.Location = new System.Drawing.Point(10, 57);
            this.startFileLoggingButton.Margin = new System.Windows.Forms.Padding(6);
            this.startFileLoggingButton.Name = "startFileLoggingButton";
            this.startFileLoggingButton.Size = new System.Drawing.Size(137, 40);
            this.startFileLoggingButton.TabIndex = 121;
            this.startFileLoggingButton.Text = "Start File Logging";
            this.startFileLoggingButton.UseVisualStyleBackColor = false;
            this.startFileLoggingButton.Click += new System.EventHandler(this.Start_Log_Click);
            // 
            // toLogSettingsButton
            // 
            this.toLogSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toLogSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toLogSettingsButton.ForeColor = System.Drawing.Color.White;
            this.toLogSettingsButton.Location = new System.Drawing.Point(10, 97);
            this.toLogSettingsButton.Margin = new System.Windows.Forms.Padding(6);
            this.toLogSettingsButton.Name = "toLogSettingsButton";
            this.toLogSettingsButton.Size = new System.Drawing.Size(137, 40);
            this.toLogSettingsButton.TabIndex = 149;
            this.toLogSettingsButton.Text = "Log Settings";
            this.toLogSettingsButton.UseVisualStyleBackColor = false;
            this.toLogSettingsButton.Click += new System.EventHandler(this.toSettingsButton_Click);
            // 
            // toTestChartPageButton
            // 
            this.toTestChartPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toTestChartPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toTestChartPageButton.ForeColor = System.Drawing.Color.White;
            this.toTestChartPageButton.Location = new System.Drawing.Point(10, 137);
            this.toTestChartPageButton.Margin = new System.Windows.Forms.Padding(6);
            this.toTestChartPageButton.Name = "toTestChartPageButton";
            this.toTestChartPageButton.Size = new System.Drawing.Size(137, 40);
            this.toTestChartPageButton.TabIndex = 252;
            this.toTestChartPageButton.Text = "Open Chart Plotter";
            this.toTestChartPageButton.UseVisualStyleBackColor = false;
            this.toTestChartPageButton.Click += new System.EventHandler(this.toTestChartPageButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(7, 177);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(176, 25);
            this.label15.TabIndex = 124;
            this.label15.Text = "Log Tick Interval:";
            // 
            // logInterval_textBox
            // 
            this.logInterval_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logInterval_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logInterval_textBox.ForeColor = System.Drawing.Color.White;
            this.logInterval_textBox.Location = new System.Drawing.Point(6, 192);
            this.logInterval_textBox.Margin = new System.Windows.Forms.Padding(6);
            this.logInterval_textBox.Name = "logInterval_textBox";
            this.logInterval_textBox.Size = new System.Drawing.Size(137, 31);
            this.logInterval_textBox.TabIndex = 123;
            this.logInterval_textBox.TextChanged += new System.EventHandler(this.logInterval_textBox_TextChanged);
            this.logInterval_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.logInterval_textBox_Keypress);
            // 
            // TickTime
            // 
            this.TickTime.AutoSize = true;
            this.TickTime.ForeColor = System.Drawing.Color.White;
            this.TickTime.Location = new System.Drawing.Point(7, 217);
            this.TickTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TickTime.Name = "TickTime";
            this.TickTime.Size = new System.Drawing.Size(156, 25);
            this.TickTime.TabIndex = 226;
            this.TickTime.Text = "Tick time: 0 ms";
            // 
            // speedTelemetrySection
            // 
            this.speedTelemetrySection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.speedTelemetrySection.Controls.Add(this.label12);
            this.speedTelemetrySection.Controls.Add(this.CurrentSpeed);
            this.speedTelemetrySection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedTelemetrySection.ForeColor = System.Drawing.Color.White;
            this.speedTelemetrySection.Location = new System.Drawing.Point(0, 430);
            this.speedTelemetrySection.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.speedTelemetrySection.Name = "speedTelemetrySection";
            this.speedTelemetrySection.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.speedTelemetrySection.Size = new System.Drawing.Size(158, 42);
            this.speedTelemetrySection.TabIndex = 2;
            this.speedTelemetrySection.TabStop = false;
            this.speedTelemetrySection.Text = "Speed";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(15, 585);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 25);
            this.label12.TabIndex = 27;
            this.label12.Text = "Speed (km/h)";
            this.label12.Visible = false;
            // 
            // CurrentSpeed
            // 
            this.CurrentSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentSpeed.BackColor = System.Drawing.Color.Transparent;
            this.CurrentSpeed.ForeColor = System.Drawing.Color.White;
            this.CurrentSpeed.Location = new System.Drawing.Point(12, 10);
            this.CurrentSpeed.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentSpeed.Name = "CurrentSpeed";
            this.CurrentSpeed.Size = new System.Drawing.Size(130, 30);
            this.CurrentSpeed.TabIndex = 28;
            this.CurrentSpeed.Text = "Current speed";
            this.CurrentSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // accelerationTelemetrySection
            // 
            this.accelerationTelemetrySection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.accelerationTelemetrySection.Controls.Add(this.label75);
            this.accelerationTelemetrySection.Controls.Add(this.CurrentAcceleration);
            this.accelerationTelemetrySection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accelerationTelemetrySection.ForeColor = System.Drawing.Color.White;
            this.accelerationTelemetrySection.Location = new System.Drawing.Point(0, 480);
            this.accelerationTelemetrySection.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.accelerationTelemetrySection.Name = "accelerationTelemetrySection";
            this.accelerationTelemetrySection.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.accelerationTelemetrySection.Size = new System.Drawing.Size(158, 42);
            this.accelerationTelemetrySection.TabIndex = 3;
            this.accelerationTelemetrySection.TabStop = false;
            this.accelerationTelemetrySection.Text = "Acceleration";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.BackColor = System.Drawing.Color.Transparent;
            this.label75.ForeColor = System.Drawing.Color.White;
            this.label75.Location = new System.Drawing.Point(15, 653);
            this.label75.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(197, 25);
            this.label75.TabIndex = 253;
            this.label75.Text = "Acceleration (m/s2)";
            this.label75.Visible = false;
            // 
            // CurrentAcceleration
            // 
            this.CurrentAcceleration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentAcceleration.BackColor = System.Drawing.Color.Transparent;
            this.CurrentAcceleration.ForeColor = System.Drawing.Color.White;
            this.CurrentAcceleration.Location = new System.Drawing.Point(12, 10);
            this.CurrentAcceleration.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentAcceleration.Name = "CurrentAcceleration";
            this.CurrentAcceleration.Size = new System.Drawing.Size(130, 30);
            this.CurrentAcceleration.TabIndex = 254;
            this.CurrentAcceleration.Text = "Current acceleration";
            this.CurrentAcceleration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gforceTelemetrySection
            // 
            this.gforceTelemetrySection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.gforceTelemetrySection.Controls.Add(this.label74);
            this.gforceTelemetrySection.Controls.Add(this.CurrentGForce);
            this.gforceTelemetrySection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gforceTelemetrySection.ForeColor = System.Drawing.Color.White;
            this.gforceTelemetrySection.Location = new System.Drawing.Point(0, 530);
            this.gforceTelemetrySection.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.gforceTelemetrySection.Name = "gforceTelemetrySection";
            this.gforceTelemetrySection.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.gforceTelemetrySection.Size = new System.Drawing.Size(158, 42);
            this.gforceTelemetrySection.TabIndex = 4;
            this.gforceTelemetrySection.TabStop = false;
            this.gforceTelemetrySection.Text = "GForce";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.Color.Transparent;
            this.label74.ForeColor = System.Drawing.Color.White;
            this.label74.Location = new System.Drawing.Point(15, 716);
            this.label74.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(90, 25);
            this.label74.TabIndex = 255;
            this.label74.Text = "G-Force";
            this.label74.Visible = false;
            // 
            // CurrentGForce
            // 
            this.CurrentGForce.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentGForce.BackColor = System.Drawing.Color.Transparent;
            this.CurrentGForce.ForeColor = System.Drawing.Color.White;
            this.CurrentGForce.Location = new System.Drawing.Point(12, 10);
            this.CurrentGForce.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentGForce.Name = "CurrentGForce";
            this.CurrentGForce.Size = new System.Drawing.Size(130, 30);
            this.CurrentGForce.TabIndex = 256;
            this.CurrentGForce.Text = "Current G-force";
            this.CurrentGForce.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aeroTelemetrySection
            // 
            this.aeroTelemetrySection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.aeroTelemetrySection.Controls.Add(this.label14);
            this.aeroTelemetrySection.Controls.Add(this.CurrentXDrag);
            this.aeroTelemetrySection.Controls.Add(this.CurrentYDrag);
            this.aeroTelemetrySection.Controls.Add(this.CurrentZDrag);
            this.aeroTelemetrySection.Controls.Add(this.CurrentTotalDrag);
            this.aeroTelemetrySection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aeroTelemetrySection.ForeColor = System.Drawing.Color.White;
            this.aeroTelemetrySection.Location = new System.Drawing.Point(0, 580);
            this.aeroTelemetrySection.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.aeroTelemetrySection.Name = "aeroTelemetrySection";
            this.aeroTelemetrySection.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.aeroTelemetrySection.Size = new System.Drawing.Size(158, 132);
            this.aeroTelemetrySection.TabIndex = 5;
            this.aeroTelemetrySection.TabStop = false;
            this.aeroTelemetrySection.Text = "Aerodynamics";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(15, 786);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(194, 22);
            this.label14.TabIndex = 30;
            this.label14.Text = "Aero Drag";
            this.label14.Visible = false;
            // 
            // CurrentXDrag
            // 
            this.CurrentXDrag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentXDrag.BackColor = System.Drawing.Color.Transparent;
            this.CurrentXDrag.ForeColor = System.Drawing.Color.White;
            this.CurrentXDrag.Location = new System.Drawing.Point(12, 10);
            this.CurrentXDrag.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentXDrag.Name = "CurrentXDrag";
            this.CurrentXDrag.Size = new System.Drawing.Size(130, 30);
            this.CurrentXDrag.TabIndex = 276;
            this.CurrentXDrag.Text = "Current X Drag";
            this.CurrentXDrag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentYDrag
            // 
            this.CurrentYDrag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentYDrag.BackColor = System.Drawing.Color.Transparent;
            this.CurrentYDrag.ForeColor = System.Drawing.Color.White;
            this.CurrentYDrag.Location = new System.Drawing.Point(12, 40);
            this.CurrentYDrag.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentYDrag.Name = "CurrentYDrag";
            this.CurrentYDrag.Size = new System.Drawing.Size(130, 30);
            this.CurrentYDrag.TabIndex = 277;
            this.CurrentYDrag.Text = "Current Y Drag";
            this.CurrentYDrag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentZDrag
            // 
            this.CurrentZDrag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentZDrag.BackColor = System.Drawing.Color.Transparent;
            this.CurrentZDrag.ForeColor = System.Drawing.Color.White;
            this.CurrentZDrag.Location = new System.Drawing.Point(12, 70);
            this.CurrentZDrag.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentZDrag.Name = "CurrentZDrag";
            this.CurrentZDrag.Size = new System.Drawing.Size(130, 30);
            this.CurrentZDrag.TabIndex = 278;
            this.CurrentZDrag.Text = "Current Z Drag";
            this.CurrentZDrag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentTotalDrag
            // 
            this.CurrentTotalDrag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTotalDrag.BackColor = System.Drawing.Color.Transparent;
            this.CurrentTotalDrag.ForeColor = System.Drawing.Color.White;
            this.CurrentTotalDrag.Location = new System.Drawing.Point(12, 100);
            this.CurrentTotalDrag.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentTotalDrag.Name = "CurrentTotalDrag";
            this.CurrentTotalDrag.Size = new System.Drawing.Size(130, 30);
            this.CurrentTotalDrag.TabIndex = 279;
            this.CurrentTotalDrag.Text = "Current Total Drag";
            this.CurrentTotalDrag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // liftTelemetrySection
            // 
            this.liftTelemetrySection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.liftTelemetrySection.Controls.Add(this.label13);
            this.liftTelemetrySection.Controls.Add(this.CurrentFrontLift);
            this.liftTelemetrySection.Controls.Add(this.CurrentRearLift);
            this.liftTelemetrySection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liftTelemetrySection.ForeColor = System.Drawing.Color.White;
            this.liftTelemetrySection.Location = new System.Drawing.Point(0, 720);
            this.liftTelemetrySection.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.liftTelemetrySection.Name = "liftTelemetrySection";
            this.liftTelemetrySection.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.liftTelemetrySection.Size = new System.Drawing.Size(158, 72);
            this.liftTelemetrySection.TabIndex = 6;
            this.liftTelemetrySection.TabStop = false;
            this.liftTelemetrySection.Text = "Lift";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(15, 905);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 25);
            this.label13.TabIndex = 29;
            this.label13.Text = "Lift (N)";
            this.label13.Visible = false;
            // 
            // CurrentFrontLift
            // 
            this.CurrentFrontLift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentFrontLift.BackColor = System.Drawing.Color.Transparent;
            this.CurrentFrontLift.ForeColor = System.Drawing.Color.White;
            this.CurrentFrontLift.Location = new System.Drawing.Point(12, 10);
            this.CurrentFrontLift.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentFrontLift.Name = "CurrentFrontLift";
            this.CurrentFrontLift.Size = new System.Drawing.Size(130, 30);
            this.CurrentFrontLift.TabIndex = 31;
            this.CurrentFrontLift.Text = "Current Front Lift";
            this.CurrentFrontLift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentRearLift
            // 
            this.CurrentRearLift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentRearLift.BackColor = System.Drawing.Color.Transparent;
            this.CurrentRearLift.ForeColor = System.Drawing.Color.White;
            this.CurrentRearLift.Location = new System.Drawing.Point(12, 40);
            this.CurrentRearLift.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentRearLift.Name = "CurrentRearLift";
            this.CurrentRearLift.Size = new System.Drawing.Size(130, 30);
            this.CurrentRearLift.TabIndex = 32;
            this.CurrentRearLift.Text = "Current Rear Lift";
            this.CurrentRearLift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // engineTelemetrySection
            // 
            this.engineTelemetrySection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.engineTelemetrySection.Controls.Add(this.label78);
            this.engineTelemetrySection.Controls.Add(this.CurrentEngineRPM);
            this.engineTelemetrySection.Controls.Add(this.CurrentEngineRPMAxle);
            this.engineTelemetrySection.Controls.Add(this.CurrentEngineTorque);
            this.engineTelemetrySection.Controls.Add(this.CurrentEnginePower);
            this.engineTelemetrySection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.engineTelemetrySection.ForeColor = System.Drawing.Color.White;
            this.engineTelemetrySection.Location = new System.Drawing.Point(0, 800);
            this.engineTelemetrySection.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.engineTelemetrySection.Name = "engineTelemetrySection";
            this.engineTelemetrySection.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.engineTelemetrySection.Size = new System.Drawing.Size(158, 132);
            this.engineTelemetrySection.TabIndex = 7;
            this.engineTelemetrySection.TabStop = false;
            this.engineTelemetrySection.Text = "Engine";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.BackColor = System.Drawing.Color.Transparent;
            this.label78.ForeColor = System.Drawing.Color.White;
            this.label78.Location = new System.Drawing.Point(15, 991);
            this.label78.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(79, 25);
            this.label78.TabIndex = 249;
            this.label78.Text = "Engine";
            this.label78.Visible = false;
            // 
            // CurrentEngineRPM
            // 
            this.CurrentEngineRPM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentEngineRPM.BackColor = System.Drawing.Color.Transparent;
            this.CurrentEngineRPM.ForeColor = System.Drawing.Color.White;
            this.CurrentEngineRPM.Location = new System.Drawing.Point(12, 10);
            this.CurrentEngineRPM.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentEngineRPM.Name = "CurrentEngineRPM";
            this.CurrentEngineRPM.Size = new System.Drawing.Size(130, 30);
            this.CurrentEngineRPM.TabIndex = 250;
            this.CurrentEngineRPM.Text = "Current RPM";
            this.CurrentEngineRPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentEngineRPMAxle
            // 
            this.CurrentEngineRPMAxle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentEngineRPMAxle.BackColor = System.Drawing.Color.Transparent;
            this.CurrentEngineRPMAxle.ForeColor = System.Drawing.Color.White;
            this.CurrentEngineRPMAxle.Location = new System.Drawing.Point(12, 40);
            this.CurrentEngineRPMAxle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentEngineRPMAxle.Name = "CurrentEngineRPMAxle";
            this.CurrentEngineRPMAxle.Size = new System.Drawing.Size(130, 30);
            this.CurrentEngineRPMAxle.TabIndex = 251;
            this.CurrentEngineRPMAxle.Text = "Current RPM Axle";
            this.CurrentEngineRPMAxle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentEngineTorque
            // 
            this.CurrentEngineTorque.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentEngineTorque.BackColor = System.Drawing.Color.Transparent;
            this.CurrentEngineTorque.ForeColor = System.Drawing.Color.White;
            this.CurrentEngineTorque.Location = new System.Drawing.Point(12, 70);
            this.CurrentEngineTorque.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentEngineTorque.Name = "CurrentEngineTorque";
            this.CurrentEngineTorque.Size = new System.Drawing.Size(130, 30);
            this.CurrentEngineTorque.TabIndex = 242;
            this.CurrentEngineTorque.Text = "Current torque (Nm)";
            this.CurrentEngineTorque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentEnginePower
            // 
            this.CurrentEnginePower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentEnginePower.BackColor = System.Drawing.Color.Transparent;
            this.CurrentEnginePower.ForeColor = System.Drawing.Color.White;
            this.CurrentEnginePower.Location = new System.Drawing.Point(12, 100);
            this.CurrentEnginePower.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentEnginePower.Name = "CurrentEnginePower";
            this.CurrentEnginePower.Size = new System.Drawing.Size(130, 30);
            this.CurrentEnginePower.TabIndex = 244;
            this.CurrentEnginePower.Text = "Current power (kW)";
            this.CurrentEnginePower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // differentialTelemetrySection
            // 
            this.differentialTelemetrySection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.differentialTelemetrySection.Controls.Add(this.Differential);
            this.differentialTelemetrySection.Controls.Add(this.differentialLeftSection);
            this.differentialTelemetrySection.Controls.Add(this.differentialRightSection);
            this.differentialTelemetrySection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.differentialTelemetrySection.ForeColor = System.Drawing.Color.White;
            this.differentialTelemetrySection.Location = new System.Drawing.Point(0, 940);
            this.differentialTelemetrySection.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.differentialTelemetrySection.Name = "differentialTelemetrySection";
            this.differentialTelemetrySection.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.differentialTelemetrySection.Size = new System.Drawing.Size(158, 247);
            this.differentialTelemetrySection.TabIndex = 8;
            this.differentialTelemetrySection.TabStop = false;
            this.differentialTelemetrySection.Text = "Differential";
            // 
            // Differential
            // 
            this.Differential.AutoSize = true;
            this.Differential.BackColor = System.Drawing.Color.Transparent;
            this.Differential.ForeColor = System.Drawing.Color.White;
            this.Differential.Location = new System.Drawing.Point(15, 1125);
            this.Differential.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Differential.Name = "Differential";
            this.Differential.Size = new System.Drawing.Size(115, 25);
            this.Differential.TabIndex = 245;
            this.Differential.Text = "Differential\r\n";
            this.Differential.Visible = false;
            // 
            // differentialLeftSection
            // 
            this.differentialLeftSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.differentialLeftSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.differentialLeftSection.Controls.Add(this.LeftLabel);
            this.differentialLeftSection.Controls.Add(this.CurrentLeftDifferentialOpen);
            this.differentialLeftSection.Controls.Add(this.CurrentLeftDifferentialSpeedRad);
            this.differentialLeftSection.Controls.Add(this.CurrentLeftDifferentialTorque);
            this.differentialLeftSection.ForeColor = System.Drawing.Color.White;
            this.differentialLeftSection.Location = new System.Drawing.Point(8, 12);
            this.differentialLeftSection.Name = "differentialLeftSection";
            this.differentialLeftSection.Size = new System.Drawing.Size(140, 110);
            this.differentialLeftSection.TabIndex = 246;
            this.differentialLeftSection.TabStop = false;
            this.differentialLeftSection.Text = "Left";
            // 
            // LeftLabel
            // 
            this.LeftLabel.AutoSize = true;
            this.LeftLabel.BackColor = System.Drawing.Color.Transparent;
            this.LeftLabel.ForeColor = System.Drawing.Color.White;
            this.LeftLabel.Location = new System.Drawing.Point(15, 1164);
            this.LeftLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LeftLabel.Name = "LeftLabel";
            this.LeftLabel.Size = new System.Drawing.Size(48, 25);
            this.LeftLabel.TabIndex = 280;
            this.LeftLabel.Text = "Left";
            this.LeftLabel.Visible = false;
            // 
            // CurrentLeftDifferentialOpen
            // 
            this.CurrentLeftDifferentialOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentLeftDifferentialOpen.BackColor = System.Drawing.Color.Transparent;
            this.CurrentLeftDifferentialOpen.ForeColor = System.Drawing.Color.White;
            this.CurrentLeftDifferentialOpen.Location = new System.Drawing.Point(12, 16);
            this.CurrentLeftDifferentialOpen.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentLeftDifferentialOpen.Name = "CurrentLeftDifferentialOpen";
            this.CurrentLeftDifferentialOpen.Size = new System.Drawing.Size(115, 30);
            this.CurrentLeftDifferentialOpen.TabIndex = 246;
            this.CurrentLeftDifferentialOpen.Text = "Diff Open/Locked";
            this.CurrentLeftDifferentialOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentLeftDifferentialSpeedRad
            // 
            this.CurrentLeftDifferentialSpeedRad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentLeftDifferentialSpeedRad.BackColor = System.Drawing.Color.Transparent;
            this.CurrentLeftDifferentialSpeedRad.ForeColor = System.Drawing.Color.White;
            this.CurrentLeftDifferentialSpeedRad.Location = new System.Drawing.Point(12, 45);
            this.CurrentLeftDifferentialSpeedRad.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentLeftDifferentialSpeedRad.Name = "CurrentLeftDifferentialSpeedRad";
            this.CurrentLeftDifferentialSpeedRad.Size = new System.Drawing.Size(115, 30);
            this.CurrentLeftDifferentialSpeedRad.TabIndex = 247;
            this.CurrentLeftDifferentialSpeedRad.Text = "Speed rad/s";
            this.CurrentLeftDifferentialSpeedRad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentLeftDifferentialTorque
            // 
            this.CurrentLeftDifferentialTorque.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentLeftDifferentialTorque.BackColor = System.Drawing.Color.Transparent;
            this.CurrentLeftDifferentialTorque.ForeColor = System.Drawing.Color.White;
            this.CurrentLeftDifferentialTorque.Location = new System.Drawing.Point(12, 75);
            this.CurrentLeftDifferentialTorque.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentLeftDifferentialTorque.Name = "CurrentLeftDifferentialTorque";
            this.CurrentLeftDifferentialTorque.Size = new System.Drawing.Size(115, 30);
            this.CurrentLeftDifferentialTorque.TabIndex = 248;
            this.CurrentLeftDifferentialTorque.Text = "Torque (Nm)";
            this.CurrentLeftDifferentialTorque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // differentialRightSection
            // 
            this.differentialRightSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.differentialRightSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.differentialRightSection.Controls.Add(this.RightLabel);
            this.differentialRightSection.Controls.Add(this.CurrentRightDifferentialOpen);
            this.differentialRightSection.Controls.Add(this.CurrentRightDifferentialSpeedRad);
            this.differentialRightSection.Controls.Add(this.CurrentRightDifferentialTorque);
            this.differentialRightSection.ForeColor = System.Drawing.Color.White;
            this.differentialRightSection.Location = new System.Drawing.Point(8, 121);
            this.differentialRightSection.Name = "differentialRightSection";
            this.differentialRightSection.Size = new System.Drawing.Size(140, 110);
            this.differentialRightSection.TabIndex = 247;
            this.differentialRightSection.TabStop = false;
            this.differentialRightSection.Text = "Right";
            // 
            // RightLabel
            // 
            this.RightLabel.AutoSize = true;
            this.RightLabel.BackColor = System.Drawing.Color.Transparent;
            this.RightLabel.ForeColor = System.Drawing.Color.White;
            this.RightLabel.Location = new System.Drawing.Point(15, 1266);
            this.RightLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.RightLabel.Name = "RightLabel";
            this.RightLabel.Size = new System.Drawing.Size(62, 25);
            this.RightLabel.TabIndex = 284;
            this.RightLabel.Text = "Right";
            this.RightLabel.Visible = false;
            // 
            // CurrentRightDifferentialOpen
            // 
            this.CurrentRightDifferentialOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentRightDifferentialOpen.BackColor = System.Drawing.Color.Transparent;
            this.CurrentRightDifferentialOpen.ForeColor = System.Drawing.Color.White;
            this.CurrentRightDifferentialOpen.Location = new System.Drawing.Point(12, 15);
            this.CurrentRightDifferentialOpen.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentRightDifferentialOpen.Name = "CurrentRightDifferentialOpen";
            this.CurrentRightDifferentialOpen.Size = new System.Drawing.Size(115, 30);
            this.CurrentRightDifferentialOpen.TabIndex = 281;
            this.CurrentRightDifferentialOpen.Text = "Diff Open/Locked";
            this.CurrentRightDifferentialOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentRightDifferentialSpeedRad
            // 
            this.CurrentRightDifferentialSpeedRad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentRightDifferentialSpeedRad.BackColor = System.Drawing.Color.Transparent;
            this.CurrentRightDifferentialSpeedRad.ForeColor = System.Drawing.Color.White;
            this.CurrentRightDifferentialSpeedRad.Location = new System.Drawing.Point(12, 45);
            this.CurrentRightDifferentialSpeedRad.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentRightDifferentialSpeedRad.Name = "CurrentRightDifferentialSpeedRad";
            this.CurrentRightDifferentialSpeedRad.Size = new System.Drawing.Size(115, 30);
            this.CurrentRightDifferentialSpeedRad.TabIndex = 282;
            this.CurrentRightDifferentialSpeedRad.Text = "Speed rad/s";
            this.CurrentRightDifferentialSpeedRad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentRightDifferentialTorque
            // 
            this.CurrentRightDifferentialTorque.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentRightDifferentialTorque.BackColor = System.Drawing.Color.Transparent;
            this.CurrentRightDifferentialTorque.ForeColor = System.Drawing.Color.White;
            this.CurrentRightDifferentialTorque.Location = new System.Drawing.Point(12, 75);
            this.CurrentRightDifferentialTorque.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CurrentRightDifferentialTorque.Name = "CurrentRightDifferentialTorque";
            this.CurrentRightDifferentialTorque.Size = new System.Drawing.Size(115, 30);
            this.CurrentRightDifferentialTorque.TabIndex = 283;
            this.CurrentRightDifferentialTorque.Text = "Torque (Nm)";
            this.CurrentRightDifferentialTorque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // debugWorkspaceSplitter
            // 
            this.debugWorkspaceSplitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.debugWorkspaceSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugWorkspaceSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.debugWorkspaceSplitter.Location = new System.Drawing.Point(0, 0);
            this.debugWorkspaceSplitter.Name = "debugWorkspaceSplitter";
            // 
            // debugWorkspaceSplitter.Panel1
            // 
            this.debugWorkspaceSplitter.Panel1.Controls.Add(this.wheelTelemetryColumn);
            // 
            // debugWorkspaceSplitter.Panel2
            // 
            this.debugWorkspaceSplitter.Panel2.Controls.Add(this.debugWorkspacePanel);
            this.debugWorkspaceSplitter.Size = new System.Drawing.Size(1689, 1368);
            this.debugWorkspaceSplitter.SplitterDistance = 1295;
            this.debugWorkspaceSplitter.SplitterWidth = 6;
            this.debugWorkspaceSplitter.TabIndex = 0;
            // 
            // wheelTelemetryColumn
            // 
            this.wheelTelemetryColumn.BackColor = System.Drawing.Color.Black;
            this.wheelTelemetryColumn.ColumnCount = 1;
            this.wheelTelemetryColumn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.wheelTelemetryColumn.Controls.Add(this.checkBox1, 0, 0);
            this.wheelTelemetryColumn.Controls.Add(this.fourWheelScrollPanel, 0, 1);
            this.wheelTelemetryColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wheelTelemetryColumn.Location = new System.Drawing.Point(0, 0);
            this.wheelTelemetryColumn.Margin = new System.Windows.Forms.Padding(0);
            this.wheelTelemetryColumn.Name = "wheelTelemetryColumn";
            this.wheelTelemetryColumn.RowCount = 2;
            this.wheelTelemetryColumn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.wheelTelemetryColumn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.wheelTelemetryColumn.Size = new System.Drawing.Size(1295, 1368);
            this.wheelTelemetryColumn.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.DimGray;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(5, 5);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(1285, 33);
            this.checkBox1.TabIndex = 274;
            this.checkBox1.Text = "Text Box updates on. (Tick off to save resources if you\'re logging data etc.)";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // fourWheelScrollPanel
            // 
            this.fourWheelScrollPanel.AutoScroll = true;
            this.fourWheelScrollPanel.BackColor = System.Drawing.Color.Black;
            this.fourWheelScrollPanel.Controls.Add(this.fourWheelGrid);
            this.fourWheelScrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fourWheelScrollPanel.Location = new System.Drawing.Point(3, 45);
            this.fourWheelScrollPanel.Name = "fourWheelScrollPanel";
            this.fourWheelScrollPanel.Size = new System.Drawing.Size(1289, 1320);
            this.fourWheelScrollPanel.TabIndex = 275;
            // 
            // fourWheelGrid
            // 
            this.fourWheelGrid.BackColor = System.Drawing.Color.Black;
            this.fourWheelGrid.ColumnCount = 2;
            this.fourWheelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fourWheelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fourWheelGrid.Controls.Add(this.panel1TelemetryCard, 0, 0);
            this.fourWheelGrid.Controls.Add(this.panel2TelemetryCard, 1, 0);
            this.fourWheelGrid.Controls.Add(this.panel3TelemetryCard, 0, 1);
            this.fourWheelGrid.Controls.Add(this.panel4TelemetryCard, 1, 1);
            this.fourWheelGrid.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.fourWheelGrid.Location = new System.Drawing.Point(0, 0);
            this.fourWheelGrid.Name = "fourWheelGrid";
            this.fourWheelGrid.RowCount = 2;
            this.fourWheelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 448F));
            this.fourWheelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 448F));
            this.fourWheelGrid.Size = new System.Drawing.Size(1200, 896);
            this.fourWheelGrid.TabIndex = 0;
            // 
            // panel1TelemetryCard
            // 
            this.panel1TelemetryCard.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryCard.Controls.Add(this.panel1);
            this.panel1TelemetryCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1TelemetryCard.ForeColor = System.Drawing.Color.White;
            this.panel1TelemetryCard.Location = new System.Drawing.Point(3, 3);
            this.panel1TelemetryCard.Name = "panel1TelemetryCard";
            this.panel1TelemetryCard.Padding = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.panel1TelemetryCard.Size = new System.Drawing.Size(594, 442);
            this.panel1TelemetryCard.TabIndex = 0;
            this.panel1TelemetryCard.TabStop = false;
            this.panel1TelemetryCard.Text = "FRONT LEFT DATA";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel1TelemetryRow0);
            this.panel1.Controls.Add(this.panel1TelemetryRow1);
            this.panel1.Controls.Add(this.panel1TelemetryRow2);
            this.panel1.Controls.Add(this.panel1TelemetryRow3);
            this.panel1.Controls.Add(this.panel1TelemetryRow4);
            this.panel1.Controls.Add(this.panel1TelemetryRow5);
            this.panel1.Controls.Add(this.panel1TelemetryRow6);
            this.panel1.Controls.Add(this.panel1TelemetryRow7);
            this.panel1.Controls.Add(this.panel1TelemetryRow8);
            this.panel1.Controls.Add(this.panel1TelemetryRow9);
            this.panel1.Controls.Add(this.panel1TelemetryRow10);
            this.panel1.Controls.Add(this.panel1TelemetryRow11);
            this.panel1.Controls.Add(this.panel1TelemetryRow12);
            this.panel1.Controls.Add(this.panel1TelemetryRow13);
            this.panel1.Controls.Add(this.panel1TelemetryRow14);
            this.panel1.Controls.Add(this.panel1TelemetryRow15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 39);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 400);
            this.panel1.TabIndex = 288;
            // 
            // panel1TelemetryRow0
            // 
            this.panel1TelemetryRow0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow0.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow0.Controls.Add(this.label1);
            this.panel1TelemetryRow0.Controls.Add(this.label_FL_TravelSpeed);
            this.panel1TelemetryRow0.Controls.Add(this.label52);
            this.panel1TelemetryRow0.Location = new System.Drawing.Point(4, 5);
            this.panel1TelemetryRow0.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow0.Name = "panel1TelemetryRow0";
            this.panel1TelemetryRow0.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow0.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.MinimumSize = new System.Drawing.Size(0, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 31);
            this.label1.TabIndex = 162;
            this.label1.Text = "Tire Travel Speed\r\n";
            // 
            // label_FL_TravelSpeed
            // 
            this.label_FL_TravelSpeed.BackColor = System.Drawing.Color.Black;
            this.label_FL_TravelSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_TravelSpeed.ForeColor = System.Drawing.Color.White;
            this.label_FL_TravelSpeed.Location = new System.Drawing.Point(165, 2);
            this.label_FL_TravelSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_TravelSpeed.Name = "label_FL_TravelSpeed";
            this.label_FL_TravelSpeed.Size = new System.Drawing.Size(220, 22);
            this.label_FL_TravelSpeed.TabIndex = 61;
            this.label_FL_TravelSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.Black;
            this.label52.ForeColor = System.Drawing.Color.White;
            this.label52.Location = new System.Drawing.Point(389, 2);
            this.label52.MinimumSize = new System.Drawing.Size(0, 31);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(49, 31);
            this.label52.TabIndex = 1;
            this.label52.Text = "m/s";
            // 
            // panel1TelemetryRow1
            // 
            this.panel1TelemetryRow1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow1.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow1.Controls.Add(this.label2);
            this.panel1TelemetryRow1.Controls.Add(this.label_FL_AngularVelocity);
            this.panel1TelemetryRow1.Controls.Add(this.label53);
            this.panel1TelemetryRow1.Location = new System.Drawing.Point(4, 31);
            this.panel1TelemetryRow1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow1.Name = "panel1TelemetryRow1";
            this.panel1TelemetryRow1.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.MinimumSize = new System.Drawing.Size(0, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 31);
            this.label2.TabIndex = 163;
            this.label2.Text = "Angular Velocity";
            // 
            // label_FL_AngularVelocity
            // 
            this.label_FL_AngularVelocity.BackColor = System.Drawing.Color.Black;
            this.label_FL_AngularVelocity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_AngularVelocity.ForeColor = System.Drawing.Color.White;
            this.label_FL_AngularVelocity.Location = new System.Drawing.Point(165, 2);
            this.label_FL_AngularVelocity.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_AngularVelocity.Name = "label_FL_AngularVelocity";
            this.label_FL_AngularVelocity.Size = new System.Drawing.Size(220, 22);
            this.label_FL_AngularVelocity.TabIndex = 46;
            this.label_FL_AngularVelocity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Black;
            this.label53.ForeColor = System.Drawing.Color.White;
            this.label53.Location = new System.Drawing.Point(389, 2);
            this.label53.MinimumSize = new System.Drawing.Size(0, 31);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(60, 31);
            this.label53.TabIndex = 2;
            this.label53.Text = "km/h";
            // 
            // panel1TelemetryRow2
            // 
            this.panel1TelemetryRow2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow2.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow2.Controls.Add(this.label3);
            this.panel1TelemetryRow2.Controls.Add(this.label_FL_VerticalLoad);
            this.panel1TelemetryRow2.Controls.Add(this.label69);
            this.panel1TelemetryRow2.Controls.Add(this.label_FL_Deflection);
            this.panel1TelemetryRow2.Controls.Add(this.label76);
            this.panel1TelemetryRow2.Location = new System.Drawing.Point(4, 57);
            this.panel1TelemetryRow2.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow2.Name = "panel1TelemetryRow2";
            this.panel1TelemetryRow2.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.MinimumSize = new System.Drawing.Size(0, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 31);
            this.label3.TabIndex = 164;
            this.label3.Text = "Vertical Load/Deflection";
            // 
            // label_FL_VerticalLoad
            // 
            this.label_FL_VerticalLoad.BackColor = System.Drawing.Color.Black;
            this.label_FL_VerticalLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_VerticalLoad.ForeColor = System.Drawing.Color.White;
            this.label_FL_VerticalLoad.Location = new System.Drawing.Point(165, 2);
            this.label_FL_VerticalLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_VerticalLoad.Name = "label_FL_VerticalLoad";
            this.label_FL_VerticalLoad.Size = new System.Drawing.Size(210, 22);
            this.label_FL_VerticalLoad.TabIndex = 54;
            this.label_FL_VerticalLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.Black;
            this.label69.ForeColor = System.Drawing.Color.White;
            this.label69.Location = new System.Drawing.Point(379, 2);
            this.label69.MinimumSize = new System.Drawing.Size(0, 31);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(42, 31);
            this.label69.TabIndex = 3;
            this.label69.Text = "N /";
            // 
            // label_FL_Deflection
            // 
            this.label_FL_Deflection.BackColor = System.Drawing.Color.Black;
            this.label_FL_Deflection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_Deflection.ForeColor = System.Drawing.Color.White;
            this.label_FL_Deflection.Location = new System.Drawing.Point(425, 2);
            this.label_FL_Deflection.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_Deflection.Name = "label_FL_Deflection";
            this.label_FL_Deflection.Size = new System.Drawing.Size(210, 22);
            this.label_FL_Deflection.TabIndex = 49;
            this.label_FL_Deflection.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.Color.Black;
            this.label76.ForeColor = System.Drawing.Color.White;
            this.label76.Location = new System.Drawing.Point(639, 2);
            this.label76.MinimumSize = new System.Drawing.Size(0, 31);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(32, 31);
            this.label76.TabIndex = 4;
            this.label76.Text = "m";
            // 
            // panel1TelemetryRow3
            // 
            this.panel1TelemetryRow3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow3.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow3.Controls.Add(this.label4);
            this.panel1TelemetryRow3.Controls.Add(this.label_FL_LoadedRadius);
            this.panel1TelemetryRow3.Controls.Add(this.label77);
            this.panel1TelemetryRow3.Controls.Add(this.label_FL_EffectiveRadius);
            this.panel1TelemetryRow3.Controls.Add(this.label79);
            this.panel1TelemetryRow3.Location = new System.Drawing.Point(4, 83);
            this.panel1TelemetryRow3.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow3.Name = "panel1TelemetryRow3";
            this.panel1TelemetryRow3.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.MinimumSize = new System.Drawing.Size(0, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 31);
            this.label4.TabIndex = 165;
            this.label4.Text = "Loaded/Effective Radius";
            // 
            // label_FL_LoadedRadius
            // 
            this.label_FL_LoadedRadius.BackColor = System.Drawing.Color.Black;
            this.label_FL_LoadedRadius.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_LoadedRadius.ForeColor = System.Drawing.Color.White;
            this.label_FL_LoadedRadius.Location = new System.Drawing.Point(165, 2);
            this.label_FL_LoadedRadius.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_LoadedRadius.Name = "label_FL_LoadedRadius";
            this.label_FL_LoadedRadius.Size = new System.Drawing.Size(209, 22);
            this.label_FL_LoadedRadius.TabIndex = 50;
            this.label_FL_LoadedRadius.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.Black;
            this.label77.ForeColor = System.Drawing.Color.White;
            this.label77.Location = new System.Drawing.Point(378, 2);
            this.label77.MinimumSize = new System.Drawing.Size(0, 31);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(44, 31);
            this.label77.TabIndex = 5;
            this.label77.Text = "m /";
            // 
            // label_FL_EffectiveRadius
            // 
            this.label_FL_EffectiveRadius.BackColor = System.Drawing.Color.Black;
            this.label_FL_EffectiveRadius.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_EffectiveRadius.ForeColor = System.Drawing.Color.White;
            this.label_FL_EffectiveRadius.Location = new System.Drawing.Point(426, 2);
            this.label_FL_EffectiveRadius.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_EffectiveRadius.Name = "label_FL_EffectiveRadius";
            this.label_FL_EffectiveRadius.Size = new System.Drawing.Size(209, 22);
            this.label_FL_EffectiveRadius.TabIndex = 51;
            this.label_FL_EffectiveRadius.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.Black;
            this.label79.ForeColor = System.Drawing.Color.White;
            this.label79.Location = new System.Drawing.Point(639, 2);
            this.label79.MinimumSize = new System.Drawing.Size(0, 31);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(32, 31);
            this.label79.TabIndex = 6;
            this.label79.Text = "m";
            // 
            // panel1TelemetryRow4
            // 
            this.panel1TelemetryRow4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow4.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow4.Controls.Add(this.label5);
            this.panel1TelemetryRow4.Controls.Add(this.label_FL_ContactLength);
            this.panel1TelemetryRow4.Controls.Add(this.label80);
            this.panel1TelemetryRow4.Location = new System.Drawing.Point(4, 109);
            this.panel1TelemetryRow4.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow4.Name = "panel1TelemetryRow4";
            this.panel1TelemetryRow4.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow4.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 2);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.MinimumSize = new System.Drawing.Size(0, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 31);
            this.label5.TabIndex = 166;
            this.label5.Text = "Contact Length";
            // 
            // label_FL_ContactLength
            // 
            this.label_FL_ContactLength.BackColor = System.Drawing.Color.Black;
            this.label_FL_ContactLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_ContactLength.ForeColor = System.Drawing.Color.White;
            this.label_FL_ContactLength.Location = new System.Drawing.Point(165, 2);
            this.label_FL_ContactLength.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_ContactLength.Name = "label_FL_ContactLength";
            this.label_FL_ContactLength.Size = new System.Drawing.Size(220, 22);
            this.label_FL_ContactLength.TabIndex = 60;
            this.label_FL_ContactLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.Black;
            this.label80.ForeColor = System.Drawing.Color.White;
            this.label80.Location = new System.Drawing.Point(389, 2);
            this.label80.MinimumSize = new System.Drawing.Size(0, 31);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(32, 31);
            this.label80.TabIndex = 7;
            this.label80.Text = "m";
            // 
            // panel1TelemetryRow5
            // 
            this.panel1TelemetryRow5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow5.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow5.Controls.Add(this.label6);
            this.panel1TelemetryRow5.Controls.Add(this.label_FL_CurrentContactBrakeTorque);
            this.panel1TelemetryRow5.Controls.Add(this.label81);
            this.panel1TelemetryRow5.Controls.Add(this.label_FL_MaxCurrentContactBrakeTorque);
            this.panel1TelemetryRow5.Controls.Add(this.label82);
            this.panel1TelemetryRow5.Location = new System.Drawing.Point(4, 135);
            this.panel1TelemetryRow5.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow5.Name = "panel1TelemetryRow5";
            this.panel1TelemetryRow5.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow5.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 2);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.MinimumSize = new System.Drawing.Size(0, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 31);
            this.label6.TabIndex = 167;
            this.label6.Text = "Braking Torque";
            // 
            // label_FL_CurrentContactBrakeTorque
            // 
            this.label_FL_CurrentContactBrakeTorque.BackColor = System.Drawing.Color.Black;
            this.label_FL_CurrentContactBrakeTorque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_CurrentContactBrakeTorque.ForeColor = System.Drawing.Color.White;
            this.label_FL_CurrentContactBrakeTorque.Location = new System.Drawing.Point(165, 2);
            this.label_FL_CurrentContactBrakeTorque.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_CurrentContactBrakeTorque.Name = "label_FL_CurrentContactBrakeTorque";
            this.label_FL_CurrentContactBrakeTorque.Size = new System.Drawing.Size(210, 22);
            this.label_FL_CurrentContactBrakeTorque.TabIndex = 52;
            this.label_FL_CurrentContactBrakeTorque.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.Black;
            this.label81.ForeColor = System.Drawing.Color.White;
            this.label81.Location = new System.Drawing.Point(379, 2);
            this.label81.MinimumSize = new System.Drawing.Size(0, 31);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(27, 31);
            this.label81.TabIndex = 8;
            this.label81.Text = " /";
            // 
            // label_FL_MaxCurrentContactBrakeTorque
            // 
            this.label_FL_MaxCurrentContactBrakeTorque.BackColor = System.Drawing.Color.Black;
            this.label_FL_MaxCurrentContactBrakeTorque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_MaxCurrentContactBrakeTorque.ForeColor = System.Drawing.Color.White;
            this.label_FL_MaxCurrentContactBrakeTorque.Location = new System.Drawing.Point(410, 2);
            this.label_FL_MaxCurrentContactBrakeTorque.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_MaxCurrentContactBrakeTorque.Name = "label_FL_MaxCurrentContactBrakeTorque";
            this.label_FL_MaxCurrentContactBrakeTorque.Size = new System.Drawing.Size(210, 22);
            this.label_FL_MaxCurrentContactBrakeTorque.TabIndex = 151;
            this.label_FL_MaxCurrentContactBrakeTorque.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.Color.Black;
            this.label82.ForeColor = System.Drawing.Color.White;
            this.label82.Location = new System.Drawing.Point(624, 2);
            this.label82.MinimumSize = new System.Drawing.Size(0, 31);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(47, 31);
            this.label82.TabIndex = 9;
            this.label82.Text = "Nm";
            // 
            // panel1TelemetryRow6
            // 
            this.panel1TelemetryRow6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow6.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow6.Controls.Add(this.label8);
            this.panel1TelemetryRow6.Controls.Add(this.label_FL_LateralLoad);
            this.panel1TelemetryRow6.Controls.Add(this.label83);
            this.panel1TelemetryRow6.Controls.Add(this.label_FL_LongitudinalLoad);
            this.panel1TelemetryRow6.Controls.Add(this.label84);
            this.panel1TelemetryRow6.Location = new System.Drawing.Point(4, 161);
            this.panel1TelemetryRow6.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow6.Name = "panel1TelemetryRow6";
            this.panel1TelemetryRow6.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow6.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(4, 2);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.MinimumSize = new System.Drawing.Size(0, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 31);
            this.label8.TabIndex = 169;
            this.label8.Text = "Lat/Lon Load";
            // 
            // label_FL_LateralLoad
            // 
            this.label_FL_LateralLoad.BackColor = System.Drawing.Color.Black;
            this.label_FL_LateralLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_LateralLoad.ForeColor = System.Drawing.Color.White;
            this.label_FL_LateralLoad.Location = new System.Drawing.Point(165, 2);
            this.label_FL_LateralLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_LateralLoad.Name = "label_FL_LateralLoad";
            this.label_FL_LateralLoad.Size = new System.Drawing.Size(218, 22);
            this.label_FL_LateralLoad.TabIndex = 55;
            this.label_FL_LateralLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.Color.Black;
            this.label83.ForeColor = System.Drawing.Color.White;
            this.label83.Location = new System.Drawing.Point(387, 2);
            this.label83.MinimumSize = new System.Drawing.Size(0, 31);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(27, 31);
            this.label83.TabIndex = 10;
            this.label83.Text = " /";
            // 
            // label_FL_LongitudinalLoad
            // 
            this.label_FL_LongitudinalLoad.BackColor = System.Drawing.Color.Black;
            this.label_FL_LongitudinalLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_LongitudinalLoad.ForeColor = System.Drawing.Color.White;
            this.label_FL_LongitudinalLoad.Location = new System.Drawing.Point(418, 2);
            this.label_FL_LongitudinalLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_LongitudinalLoad.Name = "label_FL_LongitudinalLoad";
            this.label_FL_LongitudinalLoad.Size = new System.Drawing.Size(218, 22);
            this.label_FL_LongitudinalLoad.TabIndex = 56;
            this.label_FL_LongitudinalLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.Color.Black;
            this.label84.ForeColor = System.Drawing.Color.White;
            this.label84.Location = new System.Drawing.Point(640, 2);
            this.label84.MinimumSize = new System.Drawing.Size(0, 31);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(30, 31);
            this.label84.TabIndex = 11;
            this.label84.Text = "N";
            // 
            // panel1TelemetryRow7
            // 
            this.panel1TelemetryRow7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow7.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow7.Controls.Add(this.label9);
            this.panel1TelemetryRow7.Controls.Add(this.label_FL_SlipAngleDeg);
            this.panel1TelemetryRow7.Controls.Add(this.label85);
            this.panel1TelemetryRow7.Controls.Add(this.label_FL_SlipRatio);
            this.panel1TelemetryRow7.Controls.Add(this.label86);
            this.panel1TelemetryRow7.Location = new System.Drawing.Point(4, 187);
            this.panel1TelemetryRow7.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow7.Name = "panel1TelemetryRow7";
            this.panel1TelemetryRow7.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow7.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(4, 2);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.MinimumSize = new System.Drawing.Size(0, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 31);
            this.label9.TabIndex = 170;
            this.label9.Text = "Slip Angle/Ratio";
            // 
            // label_FL_SlipAngleDeg
            // 
            this.label_FL_SlipAngleDeg.BackColor = System.Drawing.Color.Black;
            this.label_FL_SlipAngleDeg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_SlipAngleDeg.ForeColor = System.Drawing.Color.White;
            this.label_FL_SlipAngleDeg.Location = new System.Drawing.Point(165, 2);
            this.label_FL_SlipAngleDeg.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_SlipAngleDeg.Name = "label_FL_SlipAngleDeg";
            this.label_FL_SlipAngleDeg.Size = new System.Drawing.Size(206, 22);
            this.label_FL_SlipAngleDeg.TabIndex = 58;
            this.label_FL_SlipAngleDeg.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label85
            // 
            this.label85.BackColor = System.Drawing.Color.Black;
            this.label85.ForeColor = System.Drawing.Color.White;
            this.label85.Location = new System.Drawing.Point(375, 2);
            this.label85.MinimumSize = new System.Drawing.Size(0, 31);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(35, 31);
            this.label85.TabIndex = 12;
            this.label85.Text = "° /";
            // 
            // label_FL_SlipRatio
            // 
            this.label_FL_SlipRatio.BackColor = System.Drawing.Color.Black;
            this.label_FL_SlipRatio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_SlipRatio.ForeColor = System.Drawing.Color.White;
            this.label_FL_SlipRatio.Location = new System.Drawing.Point(414, 2);
            this.label_FL_SlipRatio.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_SlipRatio.Name = "label_FL_SlipRatio";
            this.label_FL_SlipRatio.Size = new System.Drawing.Size(206, 22);
            this.label_FL_SlipRatio.TabIndex = 59;
            this.label_FL_SlipRatio.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label86
            // 
            this.label86.BackColor = System.Drawing.Color.Black;
            this.label86.ForeColor = System.Drawing.Color.White;
            this.label86.Location = new System.Drawing.Point(624, 2);
            this.label86.MinimumSize = new System.Drawing.Size(0, 31);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(46, 31);
            this.label86.TabIndex = 13;
            this.label86.Text = "0-1";
            // 
            // panel1TelemetryRow8
            // 
            this.panel1TelemetryRow8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow8.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow8.Controls.Add(this.label10);
            this.panel1TelemetryRow8.Controls.Add(this.label_FL_LateralFriction);
            this.panel1TelemetryRow8.Controls.Add(this.label87);
            this.panel1TelemetryRow8.Controls.Add(this.label_FL_LongitudinalFriction);
            this.panel1TelemetryRow8.Controls.Add(this.label88);
            this.panel1TelemetryRow8.Location = new System.Drawing.Point(4, 213);
            this.panel1TelemetryRow8.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow8.Name = "panel1TelemetryRow8";
            this.panel1TelemetryRow8.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow8.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(4, 2);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.MinimumSize = new System.Drawing.Size(0, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 31);
            this.label10.TabIndex = 171;
            this.label10.Text = "Lat/Lon Friction";
            // 
            // label_FL_LateralFriction
            // 
            this.label_FL_LateralFriction.BackColor = System.Drawing.Color.Black;
            this.label_FL_LateralFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_LateralFriction.ForeColor = System.Drawing.Color.White;
            this.label_FL_LateralFriction.Location = new System.Drawing.Point(165, 2);
            this.label_FL_LateralFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_LateralFriction.Name = "label_FL_LateralFriction";
            this.label_FL_LateralFriction.Size = new System.Drawing.Size(220, 22);
            this.label_FL_LateralFriction.TabIndex = 62;
            this.label_FL_LateralFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label87
            // 
            this.label87.BackColor = System.Drawing.Color.Black;
            this.label87.ForeColor = System.Drawing.Color.White;
            this.label87.Location = new System.Drawing.Point(389, 2);
            this.label87.MinimumSize = new System.Drawing.Size(0, 31);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(27, 31);
            this.label87.TabIndex = 14;
            this.label87.Text = " /";
            // 
            // label_FL_LongitudinalFriction
            // 
            this.label_FL_LongitudinalFriction.BackColor = System.Drawing.Color.Black;
            this.label_FL_LongitudinalFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_LongitudinalFriction.ForeColor = System.Drawing.Color.White;
            this.label_FL_LongitudinalFriction.Location = new System.Drawing.Point(420, 2);
            this.label_FL_LongitudinalFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_LongitudinalFriction.Name = "label_FL_LongitudinalFriction";
            this.label_FL_LongitudinalFriction.Size = new System.Drawing.Size(220, 22);
            this.label_FL_LongitudinalFriction.TabIndex = 63;
            this.label_FL_LongitudinalFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label88
            // 
            this.label88.BackColor = System.Drawing.Color.Black;
            this.label88.ForeColor = System.Drawing.Color.White;
            this.label88.Location = new System.Drawing.Point(644, 2);
            this.label88.MinimumSize = new System.Drawing.Size(0, 31);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(27, 31);
            this.label88.TabIndex = 15;
            this.label88.Text = "μ";
            // 
            // panel1TelemetryRow9
            // 
            this.panel1TelemetryRow9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow9.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow9.Controls.Add(this.label11);
            this.panel1TelemetryRow9.Controls.Add(this.label_FL_LateralSlipSpeed);
            this.panel1TelemetryRow9.Controls.Add(this.label89);
            this.panel1TelemetryRow9.Controls.Add(this.label_FL_LongitudinalSlipSpeed);
            this.panel1TelemetryRow9.Controls.Add(this.label90);
            this.panel1TelemetryRow9.Location = new System.Drawing.Point(4, 239);
            this.panel1TelemetryRow9.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow9.Name = "panel1TelemetryRow9";
            this.panel1TelemetryRow9.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow9.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(4, 2);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.MinimumSize = new System.Drawing.Size(0, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 31);
            this.label11.TabIndex = 172;
            this.label11.Text = "Lat/Lon Slip Speed";
            // 
            // label_FL_LateralSlipSpeed
            // 
            this.label_FL_LateralSlipSpeed.BackColor = System.Drawing.Color.Black;
            this.label_FL_LateralSlipSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_LateralSlipSpeed.ForeColor = System.Drawing.Color.White;
            this.label_FL_LateralSlipSpeed.Location = new System.Drawing.Point(165, 2);
            this.label_FL_LateralSlipSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_LateralSlipSpeed.Name = "label_FL_LateralSlipSpeed";
            this.label_FL_LateralSlipSpeed.Size = new System.Drawing.Size(209, 22);
            this.label_FL_LateralSlipSpeed.TabIndex = 125;
            this.label_FL_LateralSlipSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label89
            // 
            this.label89.BackColor = System.Drawing.Color.Black;
            this.label89.ForeColor = System.Drawing.Color.White;
            this.label89.Location = new System.Drawing.Point(378, 2);
            this.label89.MinimumSize = new System.Drawing.Size(0, 31);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(27, 31);
            this.label89.TabIndex = 16;
            this.label89.Text = " /";
            // 
            // label_FL_LongitudinalSlipSpeed
            // 
            this.label_FL_LongitudinalSlipSpeed.BackColor = System.Drawing.Color.Black;
            this.label_FL_LongitudinalSlipSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_LongitudinalSlipSpeed.ForeColor = System.Drawing.Color.White;
            this.label_FL_LongitudinalSlipSpeed.Location = new System.Drawing.Point(409, 2);
            this.label_FL_LongitudinalSlipSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_LongitudinalSlipSpeed.Name = "label_FL_LongitudinalSlipSpeed";
            this.label_FL_LongitudinalSlipSpeed.Size = new System.Drawing.Size(209, 22);
            this.label_FL_LongitudinalSlipSpeed.TabIndex = 126;
            this.label_FL_LongitudinalSlipSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.Black;
            this.label90.ForeColor = System.Drawing.Color.White;
            this.label90.Location = new System.Drawing.Point(622, 2);
            this.label90.MinimumSize = new System.Drawing.Size(0, 31);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(49, 31);
            this.label90.TabIndex = 17;
            this.label90.Text = "m/s";
            // 
            // panel1TelemetryRow10
            // 
            this.panel1TelemetryRow10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow10.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow10.Controls.Add(this.label18);
            this.panel1TelemetryRow10.Controls.Add(this.label_FL_TreadTemperature);
            this.panel1TelemetryRow10.Controls.Add(this.label91);
            this.panel1TelemetryRow10.Controls.Add(this.label_FL_InnerTemperature);
            this.panel1TelemetryRow10.Controls.Add(this.label92);
            this.panel1TelemetryRow10.Location = new System.Drawing.Point(4, 265);
            this.panel1TelemetryRow10.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow10.Name = "panel1TelemetryRow10";
            this.panel1TelemetryRow10.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow10.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(4, 2);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.MinimumSize = new System.Drawing.Size(0, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(158, 31);
            this.label18.TabIndex = 175;
            this.label18.Text = "Tread/Inner Temps";
            // 
            // label_FL_TreadTemperature
            // 
            this.label_FL_TreadTemperature.BackColor = System.Drawing.Color.Black;
            this.label_FL_TreadTemperature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_TreadTemperature.ForeColor = System.Drawing.Color.White;
            this.label_FL_TreadTemperature.Location = new System.Drawing.Point(165, 2);
            this.label_FL_TreadTemperature.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_TreadTemperature.Name = "label_FL_TreadTemperature";
            this.label_FL_TreadTemperature.Size = new System.Drawing.Size(203, 22);
            this.label_FL_TreadTemperature.TabIndex = 47;
            this.label_FL_TreadTemperature.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label91
            // 
            this.label91.BackColor = System.Drawing.Color.Black;
            this.label91.ForeColor = System.Drawing.Color.White;
            this.label91.Location = new System.Drawing.Point(372, 2);
            this.label91.MinimumSize = new System.Drawing.Size(0, 31);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(50, 31);
            this.label91.TabIndex = 18;
            this.label91.Text = "°C /";
            // 
            // label_FL_InnerTemperature
            // 
            this.label_FL_InnerTemperature.BackColor = System.Drawing.Color.Black;
            this.label_FL_InnerTemperature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_InnerTemperature.ForeColor = System.Drawing.Color.White;
            this.label_FL_InnerTemperature.Location = new System.Drawing.Point(426, 2);
            this.label_FL_InnerTemperature.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_InnerTemperature.Name = "label_FL_InnerTemperature";
            this.label_FL_InnerTemperature.Size = new System.Drawing.Size(203, 22);
            this.label_FL_InnerTemperature.TabIndex = 48;
            this.label_FL_InnerTemperature.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.Color.Black;
            this.label92.ForeColor = System.Drawing.Color.White;
            this.label92.Location = new System.Drawing.Point(633, 2);
            this.label92.MinimumSize = new System.Drawing.Size(0, 31);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(38, 31);
            this.label92.TabIndex = 19;
            this.label92.Text = "°C";
            // 
            // panel1TelemetryRow11
            // 
            this.panel1TelemetryRow11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow11.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow11.Controls.Add(this.label19);
            this.panel1TelemetryRow11.Controls.Add(this.label_FL_TotalFriction);
            this.panel1TelemetryRow11.Controls.Add(this.label93);
            this.panel1TelemetryRow11.Controls.Add(this.label_FL_TotalFrictionAngle);
            this.panel1TelemetryRow11.Controls.Add(this.label94);
            this.panel1TelemetryRow11.Location = new System.Drawing.Point(4, 291);
            this.panel1TelemetryRow11.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow11.Name = "panel1TelemetryRow11";
            this.panel1TelemetryRow11.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow11.TabIndex = 11;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(4, 2);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.MinimumSize = new System.Drawing.Size(0, 31);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(158, 31);
            this.label19.TabIndex = 176;
            this.label19.Text = "Total Friction/Angle";
            // 
            // label_FL_TotalFriction
            // 
            this.label_FL_TotalFriction.BackColor = System.Drawing.Color.Black;
            this.label_FL_TotalFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_TotalFriction.ForeColor = System.Drawing.Color.White;
            this.label_FL_TotalFriction.Location = new System.Drawing.Point(165, 2);
            this.label_FL_TotalFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_TotalFriction.Name = "label_FL_TotalFriction";
            this.label_FL_TotalFriction.Size = new System.Drawing.Size(216, 22);
            this.label_FL_TotalFriction.TabIndex = 141;
            this.label_FL_TotalFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label93
            // 
            this.label93.BackColor = System.Drawing.Color.Black;
            this.label93.ForeColor = System.Drawing.Color.White;
            this.label93.Location = new System.Drawing.Point(385, 2);
            this.label93.MinimumSize = new System.Drawing.Size(0, 31);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(39, 31);
            this.label93.TabIndex = 20;
            this.label93.Text = "μ /";
            // 
            // label_FL_TotalFrictionAngle
            // 
            this.label_FL_TotalFrictionAngle.BackColor = System.Drawing.Color.Black;
            this.label_FL_TotalFrictionAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_TotalFrictionAngle.ForeColor = System.Drawing.Color.White;
            this.label_FL_TotalFrictionAngle.Location = new System.Drawing.Point(428, 2);
            this.label_FL_TotalFrictionAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_TotalFrictionAngle.Name = "label_FL_TotalFrictionAngle";
            this.label_FL_TotalFrictionAngle.Size = new System.Drawing.Size(216, 22);
            this.label_FL_TotalFrictionAngle.TabIndex = 142;
            this.label_FL_TotalFrictionAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label94
            // 
            this.label94.BackColor = System.Drawing.Color.Black;
            this.label94.ForeColor = System.Drawing.Color.White;
            this.label94.Location = new System.Drawing.Point(648, 2);
            this.label94.MinimumSize = new System.Drawing.Size(0, 31);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(23, 31);
            this.label94.TabIndex = 21;
            this.label94.Text = "°";
            // 
            // panel1TelemetryRow12
            // 
            this.panel1TelemetryRow12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow12.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow12.Controls.Add(this.label70);
            this.panel1TelemetryRow12.Controls.Add(this.label_FL_SuspensionLength);
            this.panel1TelemetryRow12.Controls.Add(this.label95);
            this.panel1TelemetryRow12.Controls.Add(this.label_FL_SuspensionVelocity);
            this.panel1TelemetryRow12.Controls.Add(this.label96);
            this.panel1TelemetryRow12.Location = new System.Drawing.Point(4, 317);
            this.panel1TelemetryRow12.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow12.Name = "panel1TelemetryRow12";
            this.panel1TelemetryRow12.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow12.TabIndex = 12;
            // 
            // label70
            // 
            this.label70.ForeColor = System.Drawing.Color.White;
            this.label70.Location = new System.Drawing.Point(4, 2);
            this.label70.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label70.MinimumSize = new System.Drawing.Size(0, 31);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(158, 31);
            this.label70.TabIndex = 227;
            this.label70.Text = "Susp Length/Velocity";
            // 
            // label_FL_SuspensionLength
            // 
            this.label_FL_SuspensionLength.BackColor = System.Drawing.Color.Black;
            this.label_FL_SuspensionLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_SuspensionLength.ForeColor = System.Drawing.Color.White;
            this.label_FL_SuspensionLength.Location = new System.Drawing.Point(165, 2);
            this.label_FL_SuspensionLength.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_SuspensionLength.Name = "label_FL_SuspensionLength";
            this.label_FL_SuspensionLength.Size = new System.Drawing.Size(200, 22);
            this.label_FL_SuspensionLength.TabIndex = 228;
            this.label_FL_SuspensionLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.Color.Black;
            this.label95.ForeColor = System.Drawing.Color.White;
            this.label95.Location = new System.Drawing.Point(369, 2);
            this.label95.MinimumSize = new System.Drawing.Size(0, 31);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(44, 31);
            this.label95.TabIndex = 22;
            this.label95.Text = "m /";
            // 
            // label_FL_SuspensionVelocity
            // 
            this.label_FL_SuspensionVelocity.BackColor = System.Drawing.Color.Black;
            this.label_FL_SuspensionVelocity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_SuspensionVelocity.ForeColor = System.Drawing.Color.White;
            this.label_FL_SuspensionVelocity.Location = new System.Drawing.Point(417, 2);
            this.label_FL_SuspensionVelocity.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_SuspensionVelocity.Name = "label_FL_SuspensionVelocity";
            this.label_FL_SuspensionVelocity.Size = new System.Drawing.Size(200, 22);
            this.label_FL_SuspensionVelocity.TabIndex = 229;
            this.label_FL_SuspensionVelocity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.Black;
            this.label96.ForeColor = System.Drawing.Color.White;
            this.label96.Location = new System.Drawing.Point(621, 2);
            this.label96.MinimumSize = new System.Drawing.Size(0, 31);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(49, 31);
            this.label96.TabIndex = 23;
            this.label96.Text = "m/s";
            // 
            // panel1TelemetryRow13
            // 
            this.panel1TelemetryRow13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow13.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow13.Controls.Add(this.label7);
            this.panel1TelemetryRow13.Controls.Add(this.label_FL_TireSteerAngle);
            this.panel1TelemetryRow13.Controls.Add(this.label97);
            this.panel1TelemetryRow13.Controls.Add(this.label_FL_CamberAngle);
            this.panel1TelemetryRow13.Controls.Add(this.label98);
            this.panel1TelemetryRow13.Location = new System.Drawing.Point(4, 343);
            this.panel1TelemetryRow13.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow13.Name = "panel1TelemetryRow13";
            this.panel1TelemetryRow13.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow13.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(4, 2);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.MinimumSize = new System.Drawing.Size(0, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 31);
            this.label7.TabIndex = 168;
            this.label7.Text = "Steer/Camber Angle";
            // 
            // label_FL_TireSteerAngle
            // 
            this.label_FL_TireSteerAngle.BackColor = System.Drawing.Color.Black;
            this.label_FL_TireSteerAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_TireSteerAngle.ForeColor = System.Drawing.Color.White;
            this.label_FL_TireSteerAngle.Location = new System.Drawing.Point(165, 2);
            this.label_FL_TireSteerAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_TireSteerAngle.Name = "label_FL_TireSteerAngle";
            this.label_FL_TireSteerAngle.Size = new System.Drawing.Size(220, 22);
            this.label_FL_TireSteerAngle.TabIndex = 127;
            this.label_FL_TireSteerAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.Color.Black;
            this.label97.ForeColor = System.Drawing.Color.White;
            this.label97.Location = new System.Drawing.Point(389, 2);
            this.label97.MinimumSize = new System.Drawing.Size(0, 31);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(27, 31);
            this.label97.TabIndex = 24;
            this.label97.Text = " /";
            // 
            // label_FL_CamberAngle
            // 
            this.label_FL_CamberAngle.BackColor = System.Drawing.Color.Black;
            this.label_FL_CamberAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_CamberAngle.ForeColor = System.Drawing.Color.White;
            this.label_FL_CamberAngle.Location = new System.Drawing.Point(420, 2);
            this.label_FL_CamberAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_CamberAngle.Name = "label_FL_CamberAngle";
            this.label_FL_CamberAngle.Size = new System.Drawing.Size(220, 22);
            this.label_FL_CamberAngle.TabIndex = 128;
            this.label_FL_CamberAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.Color.Black;
            this.label98.ForeColor = System.Drawing.Color.White;
            this.label98.Location = new System.Drawing.Point(644, 2);
            this.label98.MinimumSize = new System.Drawing.Size(0, 31);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(23, 31);
            this.label98.TabIndex = 25;
            this.label98.Text = "°";
            // 
            // panel1TelemetryRow14
            // 
            this.panel1TelemetryRow14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow14.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow14.Controls.Add(this.label188);
            this.panel1TelemetryRow14.Controls.Add(this.label_FL_Mx);
            this.panel1TelemetryRow14.Controls.Add(this.label189);
            this.panel1TelemetryRow14.Controls.Add(this.label_FL_Mz);
            this.panel1TelemetryRow14.Controls.Add(this.label190);
            this.panel1TelemetryRow14.Controls.Add(this.label_FL_My);
            this.panel1TelemetryRow14.Location = new System.Drawing.Point(4, 369);
            this.panel1TelemetryRow14.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow14.Name = "panel1TelemetryRow14";
            this.panel1TelemetryRow14.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow14.TabIndex = 14;
            // 
            // label188
            // 
            this.label188.ForeColor = System.Drawing.Color.White;
            this.label188.Location = new System.Drawing.Point(4, 2);
            this.label188.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label188.MinimumSize = new System.Drawing.Size(0, 31);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(158, 31);
            this.label188.TabIndex = 233;
            this.label188.Text = "Mx/Mz/My";
            // 
            // label_FL_Mx
            // 
            this.label_FL_Mx.BackColor = System.Drawing.Color.Black;
            this.label_FL_Mx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_Mx.ForeColor = System.Drawing.Color.White;
            this.label_FL_Mx.Location = new System.Drawing.Point(165, 2);
            this.label_FL_Mx.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_Mx.Name = "label_FL_Mx";
            this.label_FL_Mx.Size = new System.Drawing.Size(145, 22);
            this.label_FL_Mx.TabIndex = 230;
            this.label_FL_Mx.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label189
            // 
            this.label189.BackColor = System.Drawing.Color.Black;
            this.label189.ForeColor = System.Drawing.Color.White;
            this.label189.Location = new System.Drawing.Point(314, 2);
            this.label189.MinimumSize = new System.Drawing.Size(0, 31);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(27, 31);
            this.label189.TabIndex = 234;
            this.label189.Text = " /";
            // 
            // label_FL_Mz
            // 
            this.label_FL_Mz.BackColor = System.Drawing.Color.Black;
            this.label_FL_Mz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_Mz.ForeColor = System.Drawing.Color.White;
            this.label_FL_Mz.Location = new System.Drawing.Point(345, 2);
            this.label_FL_Mz.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_Mz.Name = "label_FL_Mz";
            this.label_FL_Mz.Size = new System.Drawing.Size(145, 22);
            this.label_FL_Mz.TabIndex = 231;
            this.label_FL_Mz.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label190
            // 
            this.label190.BackColor = System.Drawing.Color.Black;
            this.label190.ForeColor = System.Drawing.Color.White;
            this.label190.Location = new System.Drawing.Point(494, 2);
            this.label190.MinimumSize = new System.Drawing.Size(0, 31);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(27, 31);
            this.label190.TabIndex = 235;
            this.label190.Text = " /";
            // 
            // label_FL_My
            // 
            this.label_FL_My.BackColor = System.Drawing.Color.Black;
            this.label_FL_My.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_My.ForeColor = System.Drawing.Color.White;
            this.label_FL_My.Location = new System.Drawing.Point(525, 2);
            this.label_FL_My.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_My.Name = "label_FL_My";
            this.label_FL_My.Size = new System.Drawing.Size(145, 22);
            this.label_FL_My.TabIndex = 232;
            this.label_FL_My.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1TelemetryRow15
            // 
            this.panel1TelemetryRow15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1TelemetryRow15.BackColor = System.Drawing.Color.Black;
            this.panel1TelemetryRow15.Controls.Add(this.label191);
            this.panel1TelemetryRow15.Controls.Add(this.label_FL_PneumaticTrail);
            this.panel1TelemetryRow15.Controls.Add(this.label193);
            this.panel1TelemetryRow15.Controls.Add(this.label_FL_RollingResistance);
            this.panel1TelemetryRow15.Location = new System.Drawing.Point(4, 395);
            this.panel1TelemetryRow15.Margin = new System.Windows.Forms.Padding(0);
            this.panel1TelemetryRow15.Name = "panel1TelemetryRow15";
            this.panel1TelemetryRow15.Size = new System.Drawing.Size(436, 24);
            this.panel1TelemetryRow15.TabIndex = 15;
            // 
            // label191
            // 
            this.label191.ForeColor = System.Drawing.Color.White;
            this.label191.Location = new System.Drawing.Point(4, 2);
            this.label191.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label191.MinimumSize = new System.Drawing.Size(0, 31);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(158, 31);
            this.label191.TabIndex = 236;
            this.label191.Text = "Pt/Rr";
            // 
            // label_FL_PneumaticTrail
            // 
            this.label_FL_PneumaticTrail.BackColor = System.Drawing.Color.Black;
            this.label_FL_PneumaticTrail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_PneumaticTrail.ForeColor = System.Drawing.Color.White;
            this.label_FL_PneumaticTrail.Location = new System.Drawing.Point(165, 2);
            this.label_FL_PneumaticTrail.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_PneumaticTrail.Name = "label_FL_PneumaticTrail";
            this.label_FL_PneumaticTrail.Size = new System.Drawing.Size(220, 22);
            this.label_FL_PneumaticTrail.TabIndex = 237;
            this.label_FL_PneumaticTrail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label193
            // 
            this.label193.BackColor = System.Drawing.Color.Black;
            this.label193.ForeColor = System.Drawing.Color.White;
            this.label193.Location = new System.Drawing.Point(389, 2);
            this.label193.MinimumSize = new System.Drawing.Size(0, 31);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(44, 31);
            this.label193.TabIndex = 238;
            this.label193.Text = "m /";
            // 
            // label_FL_RollingResistance
            // 
            this.label_FL_RollingResistance.BackColor = System.Drawing.Color.Black;
            this.label_FL_RollingResistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FL_RollingResistance.ForeColor = System.Drawing.Color.White;
            this.label_FL_RollingResistance.Location = new System.Drawing.Point(437, 2);
            this.label_FL_RollingResistance.Margin = new System.Windows.Forms.Padding(6);
            this.label_FL_RollingResistance.Name = "label_FL_RollingResistance";
            this.label_FL_RollingResistance.Size = new System.Drawing.Size(220, 22);
            this.label_FL_RollingResistance.TabIndex = 239;
            this.label_FL_RollingResistance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2TelemetryCard
            // 
            this.panel2TelemetryCard.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryCard.Controls.Add(this.panel2);
            this.panel2TelemetryCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2TelemetryCard.ForeColor = System.Drawing.Color.White;
            this.panel2TelemetryCard.Location = new System.Drawing.Point(603, 3);
            this.panel2TelemetryCard.Name = "panel2TelemetryCard";
            this.panel2TelemetryCard.Padding = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.panel2TelemetryCard.Size = new System.Drawing.Size(594, 442);
            this.panel2TelemetryCard.TabIndex = 1;
            this.panel2TelemetryCard.TabStop = false;
            this.panel2TelemetryCard.Text = "FRONT RIGHT DATA";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panel2TelemetryRow0);
            this.panel2.Controls.Add(this.panel2TelemetryRow1);
            this.panel2.Controls.Add(this.panel2TelemetryRow2);
            this.panel2.Controls.Add(this.panel2TelemetryRow3);
            this.panel2.Controls.Add(this.panel2TelemetryRow4);
            this.panel2.Controls.Add(this.panel2TelemetryRow5);
            this.panel2.Controls.Add(this.panel2TelemetryRow6);
            this.panel2.Controls.Add(this.panel2TelemetryRow7);
            this.panel2.Controls.Add(this.panel2TelemetryRow8);
            this.panel2.Controls.Add(this.panel2TelemetryRow9);
            this.panel2.Controls.Add(this.panel2TelemetryRow10);
            this.panel2.Controls.Add(this.panel2TelemetryRow11);
            this.panel2.Controls.Add(this.panel2TelemetryRow12);
            this.panel2.Controls.Add(this.panel2TelemetryRow13);
            this.panel2.Controls.Add(this.panel2TelemetryRow14);
            this.panel2.Controls.Add(this.panel2TelemetryRow15);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 39);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 400);
            this.panel2.TabIndex = 289;
            // 
            // panel2TelemetryRow0
            // 
            this.panel2TelemetryRow0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow0.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow0.Controls.Add(this.label117);
            this.panel2TelemetryRow0.Controls.Add(this.label_FR_TravelSpeed);
            this.panel2TelemetryRow0.Controls.Add(this.label71);
            this.panel2TelemetryRow0.Location = new System.Drawing.Point(4, 5);
            this.panel2TelemetryRow0.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow0.Name = "panel2TelemetryRow0";
            this.panel2TelemetryRow0.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow0.TabIndex = 0;
            // 
            // label117
            // 
            this.label117.ForeColor = System.Drawing.Color.White;
            this.label117.Location = new System.Drawing.Point(4, 2);
            this.label117.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label117.MinimumSize = new System.Drawing.Size(0, 31);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(158, 31);
            this.label117.TabIndex = 292;
            this.label117.Text = "Tire Travel Speed\r\n";
            // 
            // label_FR_TravelSpeed
            // 
            this.label_FR_TravelSpeed.BackColor = System.Drawing.Color.Black;
            this.label_FR_TravelSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_TravelSpeed.ForeColor = System.Drawing.Color.White;
            this.label_FR_TravelSpeed.Location = new System.Drawing.Point(165, 2);
            this.label_FR_TravelSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_TravelSpeed.Name = "label_FR_TravelSpeed";
            this.label_FR_TravelSpeed.Size = new System.Drawing.Size(220, 22);
            this.label_FR_TravelSpeed.TabIndex = 80;
            this.label_FR_TravelSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.Black;
            this.label71.ForeColor = System.Drawing.Color.White;
            this.label71.Location = new System.Drawing.Point(389, 2);
            this.label71.MinimumSize = new System.Drawing.Size(0, 31);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(49, 31);
            this.label71.TabIndex = 26;
            this.label71.Text = "m/s";
            // 
            // panel2TelemetryRow1
            // 
            this.panel2TelemetryRow1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow1.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow1.Controls.Add(this.label116);
            this.panel2TelemetryRow1.Controls.Add(this.label_FR_AngularVelocity);
            this.panel2TelemetryRow1.Controls.Add(this.label34);
            this.panel2TelemetryRow1.Location = new System.Drawing.Point(4, 31);
            this.panel2TelemetryRow1.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow1.Name = "panel2TelemetryRow1";
            this.panel2TelemetryRow1.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow1.TabIndex = 1;
            // 
            // label116
            // 
            this.label116.ForeColor = System.Drawing.Color.White;
            this.label116.Location = new System.Drawing.Point(4, 2);
            this.label116.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label116.MinimumSize = new System.Drawing.Size(0, 31);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(158, 31);
            this.label116.TabIndex = 293;
            this.label116.Text = "Angular Velocity";
            // 
            // label_FR_AngularVelocity
            // 
            this.label_FR_AngularVelocity.BackColor = System.Drawing.Color.Black;
            this.label_FR_AngularVelocity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_AngularVelocity.ForeColor = System.Drawing.Color.White;
            this.label_FR_AngularVelocity.Location = new System.Drawing.Point(165, 2);
            this.label_FR_AngularVelocity.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_AngularVelocity.Name = "label_FR_AngularVelocity";
            this.label_FR_AngularVelocity.Size = new System.Drawing.Size(220, 22);
            this.label_FR_AngularVelocity.TabIndex = 65;
            this.label_FR_AngularVelocity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Black;
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(389, 2);
            this.label34.MinimumSize = new System.Drawing.Size(0, 31);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(60, 31);
            this.label34.TabIndex = 27;
            this.label34.Text = "km/h";
            // 
            // panel2TelemetryRow2
            // 
            this.panel2TelemetryRow2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow2.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow2.Controls.Add(this.label115);
            this.panel2TelemetryRow2.Controls.Add(this.label_FR_VerticalLoad);
            this.panel2TelemetryRow2.Controls.Add(this.label174);
            this.panel2TelemetryRow2.Controls.Add(this.label_FR_Deflection);
            this.panel2TelemetryRow2.Controls.Add(this.label33);
            this.panel2TelemetryRow2.Controls.Add(this.label47);
            this.panel2TelemetryRow2.Location = new System.Drawing.Point(4, 57);
            this.panel2TelemetryRow2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow2.Name = "panel2TelemetryRow2";
            this.panel2TelemetryRow2.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow2.TabIndex = 2;
            // 
            // label115
            // 
            this.label115.ForeColor = System.Drawing.Color.White;
            this.label115.Location = new System.Drawing.Point(4, 2);
            this.label115.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label115.MinimumSize = new System.Drawing.Size(0, 31);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(158, 31);
            this.label115.TabIndex = 294;
            this.label115.Text = "Vertical Load/Deflection";
            // 
            // label_FR_VerticalLoad
            // 
            this.label_FR_VerticalLoad.BackColor = System.Drawing.Color.Black;
            this.label_FR_VerticalLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_VerticalLoad.ForeColor = System.Drawing.Color.White;
            this.label_FR_VerticalLoad.Location = new System.Drawing.Point(165, 2);
            this.label_FR_VerticalLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_VerticalLoad.Name = "label_FR_VerticalLoad";
            this.label_FR_VerticalLoad.Size = new System.Drawing.Size(206, 22);
            this.label_FR_VerticalLoad.TabIndex = 73;
            this.label_FR_VerticalLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label174
            // 
            this.label174.BackColor = System.Drawing.Color.Black;
            this.label174.ForeColor = System.Drawing.Color.White;
            this.label174.Location = new System.Drawing.Point(375, 2);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(50, 22);
            this.label174.TabIndex = 26;
            this.label174.Text = "N /";
            // 
            // label_FR_Deflection
            // 
            this.label_FR_Deflection.BackColor = System.Drawing.Color.Black;
            this.label_FR_Deflection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_Deflection.ForeColor = System.Drawing.Color.White;
            this.label_FR_Deflection.Location = new System.Drawing.Point(429, 2);
            this.label_FR_Deflection.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_Deflection.Name = "label_FR_Deflection";
            this.label_FR_Deflection.Size = new System.Drawing.Size(206, 22);
            this.label_FR_Deflection.TabIndex = 68;
            this.label_FR_Deflection.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Black;
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(639, 2);
            this.label33.MinimumSize = new System.Drawing.Size(0, 31);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(32, 31);
            this.label33.TabIndex = 28;
            this.label33.Text = "m";
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.Black;
            this.label47.ForeColor = System.Drawing.Color.White;
            this.label47.Location = new System.Drawing.Point(421, 155);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(39, 25);
            this.label47.TabIndex = 26;
            this.label47.Tag = "LayoutIgnoredDuplicate";
            this.label47.Text = "N /";
            this.label47.Visible = false;
            // 
            // panel2TelemetryRow3
            // 
            this.panel2TelemetryRow3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow3.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow3.Controls.Add(this.label114);
            this.panel2TelemetryRow3.Controls.Add(this.label_FR_LoadedRadius);
            this.panel2TelemetryRow3.Controls.Add(this.label175);
            this.panel2TelemetryRow3.Controls.Add(this.label_FR_EffectiveRadius);
            this.panel2TelemetryRow3.Controls.Add(this.label32);
            this.panel2TelemetryRow3.Controls.Add(this.label46);
            this.panel2TelemetryRow3.Location = new System.Drawing.Point(4, 83);
            this.panel2TelemetryRow3.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow3.Name = "panel2TelemetryRow3";
            this.panel2TelemetryRow3.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow3.TabIndex = 3;
            // 
            // label114
            // 
            this.label114.ForeColor = System.Drawing.Color.White;
            this.label114.Location = new System.Drawing.Point(4, 2);
            this.label114.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label114.MinimumSize = new System.Drawing.Size(0, 31);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(158, 31);
            this.label114.TabIndex = 295;
            this.label114.Text = "Loaded/Effective Radius";
            // 
            // label_FR_LoadedRadius
            // 
            this.label_FR_LoadedRadius.BackColor = System.Drawing.Color.Black;
            this.label_FR_LoadedRadius.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_LoadedRadius.ForeColor = System.Drawing.Color.White;
            this.label_FR_LoadedRadius.Location = new System.Drawing.Point(165, 2);
            this.label_FR_LoadedRadius.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_LoadedRadius.Name = "label_FR_LoadedRadius";
            this.label_FR_LoadedRadius.Size = new System.Drawing.Size(206, 22);
            this.label_FR_LoadedRadius.TabIndex = 69;
            this.label_FR_LoadedRadius.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label175
            // 
            this.label175.BackColor = System.Drawing.Color.Black;
            this.label175.ForeColor = System.Drawing.Color.White;
            this.label175.Location = new System.Drawing.Point(375, 2);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(50, 22);
            this.label175.TabIndex = 27;
            this.label175.Text = "m /";
            // 
            // label_FR_EffectiveRadius
            // 
            this.label_FR_EffectiveRadius.BackColor = System.Drawing.Color.Black;
            this.label_FR_EffectiveRadius.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_EffectiveRadius.ForeColor = System.Drawing.Color.White;
            this.label_FR_EffectiveRadius.Location = new System.Drawing.Point(429, 2);
            this.label_FR_EffectiveRadius.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_EffectiveRadius.Name = "label_FR_EffectiveRadius";
            this.label_FR_EffectiveRadius.Size = new System.Drawing.Size(206, 22);
            this.label_FR_EffectiveRadius.TabIndex = 70;
            this.label_FR_EffectiveRadius.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Black;
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(639, 2);
            this.label32.MinimumSize = new System.Drawing.Size(0, 31);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(32, 31);
            this.label32.TabIndex = 29;
            this.label32.Text = "m";
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.Black;
            this.label46.ForeColor = System.Drawing.Color.White;
            this.label46.Location = new System.Drawing.Point(421, 205);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(41, 25);
            this.label46.TabIndex = 27;
            this.label46.Tag = "LayoutIgnoredDuplicate";
            this.label46.Text = "m /";
            this.label46.Visible = false;
            // 
            // panel2TelemetryRow4
            // 
            this.panel2TelemetryRow4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow4.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow4.Controls.Add(this.label113);
            this.panel2TelemetryRow4.Controls.Add(this.label_FR_ContactLength);
            this.panel2TelemetryRow4.Controls.Add(this.label31);
            this.panel2TelemetryRow4.Location = new System.Drawing.Point(4, 109);
            this.panel2TelemetryRow4.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow4.Name = "panel2TelemetryRow4";
            this.panel2TelemetryRow4.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow4.TabIndex = 4;
            // 
            // label113
            // 
            this.label113.ForeColor = System.Drawing.Color.White;
            this.label113.Location = new System.Drawing.Point(4, 2);
            this.label113.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label113.MinimumSize = new System.Drawing.Size(0, 31);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(158, 31);
            this.label113.TabIndex = 296;
            this.label113.Text = "Contact Length";
            // 
            // label_FR_ContactLength
            // 
            this.label_FR_ContactLength.BackColor = System.Drawing.Color.Black;
            this.label_FR_ContactLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_ContactLength.ForeColor = System.Drawing.Color.White;
            this.label_FR_ContactLength.Location = new System.Drawing.Point(165, 2);
            this.label_FR_ContactLength.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_ContactLength.Name = "label_FR_ContactLength";
            this.label_FR_ContactLength.Size = new System.Drawing.Size(220, 22);
            this.label_FR_ContactLength.TabIndex = 79;
            this.label_FR_ContactLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Black;
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(389, 2);
            this.label31.MinimumSize = new System.Drawing.Size(0, 31);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(32, 31);
            this.label31.TabIndex = 30;
            this.label31.Text = "m";
            // 
            // panel2TelemetryRow5
            // 
            this.panel2TelemetryRow5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow5.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow5.Controls.Add(this.label112);
            this.panel2TelemetryRow5.Controls.Add(this.label_FR_CurrentContactBrakeTorque);
            this.panel2TelemetryRow5.Controls.Add(this.label176);
            this.panel2TelemetryRow5.Controls.Add(this.label_FR_MaxCurrentContactBrakeTorque);
            this.panel2TelemetryRow5.Controls.Add(this.label30);
            this.panel2TelemetryRow5.Controls.Add(this.label45);
            this.panel2TelemetryRow5.Location = new System.Drawing.Point(4, 135);
            this.panel2TelemetryRow5.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow5.Name = "panel2TelemetryRow5";
            this.panel2TelemetryRow5.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow5.TabIndex = 5;
            // 
            // label112
            // 
            this.label112.ForeColor = System.Drawing.Color.White;
            this.label112.Location = new System.Drawing.Point(4, 2);
            this.label112.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label112.MinimumSize = new System.Drawing.Size(0, 31);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(158, 31);
            this.label112.TabIndex = 297;
            this.label112.Text = "Braking Torque";
            // 
            // label_FR_CurrentContactBrakeTorque
            // 
            this.label_FR_CurrentContactBrakeTorque.BackColor = System.Drawing.Color.Black;
            this.label_FR_CurrentContactBrakeTorque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_CurrentContactBrakeTorque.ForeColor = System.Drawing.Color.White;
            this.label_FR_CurrentContactBrakeTorque.Location = new System.Drawing.Point(165, 2);
            this.label_FR_CurrentContactBrakeTorque.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_CurrentContactBrakeTorque.Name = "label_FR_CurrentContactBrakeTorque";
            this.label_FR_CurrentContactBrakeTorque.Size = new System.Drawing.Size(198, 22);
            this.label_FR_CurrentContactBrakeTorque.TabIndex = 71;
            this.label_FR_CurrentContactBrakeTorque.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label176
            // 
            this.label176.BackColor = System.Drawing.Color.Black;
            this.label176.ForeColor = System.Drawing.Color.White;
            this.label176.Location = new System.Drawing.Point(367, 2);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(50, 22);
            this.label176.TabIndex = 28;
            this.label176.Text = " /";
            // 
            // label_FR_MaxCurrentContactBrakeTorque
            // 
            this.label_FR_MaxCurrentContactBrakeTorque.BackColor = System.Drawing.Color.Black;
            this.label_FR_MaxCurrentContactBrakeTorque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_MaxCurrentContactBrakeTorque.ForeColor = System.Drawing.Color.White;
            this.label_FR_MaxCurrentContactBrakeTorque.Location = new System.Drawing.Point(421, 2);
            this.label_FR_MaxCurrentContactBrakeTorque.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_MaxCurrentContactBrakeTorque.Name = "label_FR_MaxCurrentContactBrakeTorque";
            this.label_FR_MaxCurrentContactBrakeTorque.Size = new System.Drawing.Size(198, 22);
            this.label_FR_MaxCurrentContactBrakeTorque.TabIndex = 152;
            this.label_FR_MaxCurrentContactBrakeTorque.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Black;
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(623, 2);
            this.label30.MinimumSize = new System.Drawing.Size(0, 31);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 31);
            this.label30.TabIndex = 31;
            this.label30.Text = "Nm";
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.Black;
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(421, 305);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(24, 25);
            this.label45.TabIndex = 28;
            this.label45.Tag = "LayoutIgnoredDuplicate";
            this.label45.Text = " /";
            this.label45.Visible = false;
            // 
            // panel2TelemetryRow6
            // 
            this.panel2TelemetryRow6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow6.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow6.Controls.Add(this.label110);
            this.panel2TelemetryRow6.Controls.Add(this.label_FR_LateralLoad);
            this.panel2TelemetryRow6.Controls.Add(this.label177);
            this.panel2TelemetryRow6.Controls.Add(this.label_FR_LongitudinalLoad);
            this.panel2TelemetryRow6.Controls.Add(this.label29);
            this.panel2TelemetryRow6.Controls.Add(this.label44);
            this.panel2TelemetryRow6.Location = new System.Drawing.Point(4, 161);
            this.panel2TelemetryRow6.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow6.Name = "panel2TelemetryRow6";
            this.panel2TelemetryRow6.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow6.TabIndex = 6;
            // 
            // label110
            // 
            this.label110.ForeColor = System.Drawing.Color.White;
            this.label110.Location = new System.Drawing.Point(4, 2);
            this.label110.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label110.MinimumSize = new System.Drawing.Size(0, 31);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(158, 31);
            this.label110.TabIndex = 299;
            this.label110.Text = "Lat/Lon Load";
            // 
            // label_FR_LateralLoad
            // 
            this.label_FR_LateralLoad.BackColor = System.Drawing.Color.Black;
            this.label_FR_LateralLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_LateralLoad.ForeColor = System.Drawing.Color.White;
            this.label_FR_LateralLoad.Location = new System.Drawing.Point(165, 2);
            this.label_FR_LateralLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_LateralLoad.Name = "label_FR_LateralLoad";
            this.label_FR_LateralLoad.Size = new System.Drawing.Size(207, 22);
            this.label_FR_LateralLoad.TabIndex = 74;
            this.label_FR_LateralLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label177
            // 
            this.label177.BackColor = System.Drawing.Color.Black;
            this.label177.ForeColor = System.Drawing.Color.White;
            this.label177.Location = new System.Drawing.Point(376, 2);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(50, 22);
            this.label177.TabIndex = 29;
            this.label177.Text = " /";
            // 
            // label_FR_LongitudinalLoad
            // 
            this.label_FR_LongitudinalLoad.BackColor = System.Drawing.Color.Black;
            this.label_FR_LongitudinalLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_LongitudinalLoad.ForeColor = System.Drawing.Color.White;
            this.label_FR_LongitudinalLoad.Location = new System.Drawing.Point(430, 2);
            this.label_FR_LongitudinalLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_LongitudinalLoad.Name = "label_FR_LongitudinalLoad";
            this.label_FR_LongitudinalLoad.Size = new System.Drawing.Size(207, 22);
            this.label_FR_LongitudinalLoad.TabIndex = 75;
            this.label_FR_LongitudinalLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Black;
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(641, 2);
            this.label29.MinimumSize = new System.Drawing.Size(0, 31);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(30, 31);
            this.label29.TabIndex = 32;
            this.label29.Text = "N";
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Black;
            this.label44.ForeColor = System.Drawing.Color.White;
            this.label44.Location = new System.Drawing.Point(421, 355);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(24, 25);
            this.label44.TabIndex = 29;
            this.label44.Tag = "LayoutIgnoredDuplicate";
            this.label44.Text = " /";
            this.label44.Visible = false;
            // 
            // panel2TelemetryRow7
            // 
            this.panel2TelemetryRow7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow7.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow7.Controls.Add(this.label109);
            this.panel2TelemetryRow7.Controls.Add(this.label_FR_SlipAngleDeg);
            this.panel2TelemetryRow7.Controls.Add(this.label178);
            this.panel2TelemetryRow7.Controls.Add(this.label_FR_SlipRatio);
            this.panel2TelemetryRow7.Controls.Add(this.label28);
            this.panel2TelemetryRow7.Controls.Add(this.label43);
            this.panel2TelemetryRow7.Location = new System.Drawing.Point(4, 187);
            this.panel2TelemetryRow7.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow7.Name = "panel2TelemetryRow7";
            this.panel2TelemetryRow7.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow7.TabIndex = 7;
            // 
            // label109
            // 
            this.label109.ForeColor = System.Drawing.Color.White;
            this.label109.Location = new System.Drawing.Point(4, 2);
            this.label109.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label109.MinimumSize = new System.Drawing.Size(0, 31);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(158, 31);
            this.label109.TabIndex = 300;
            this.label109.Text = "Slip Angle/Ratio";
            // 
            // label_FR_SlipAngleDeg
            // 
            this.label_FR_SlipAngleDeg.BackColor = System.Drawing.Color.Black;
            this.label_FR_SlipAngleDeg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_SlipAngleDeg.ForeColor = System.Drawing.Color.White;
            this.label_FR_SlipAngleDeg.Location = new System.Drawing.Point(165, 2);
            this.label_FR_SlipAngleDeg.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_SlipAngleDeg.Name = "label_FR_SlipAngleDeg";
            this.label_FR_SlipAngleDeg.Size = new System.Drawing.Size(199, 22);
            this.label_FR_SlipAngleDeg.TabIndex = 77;
            this.label_FR_SlipAngleDeg.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label178
            // 
            this.label178.BackColor = System.Drawing.Color.Black;
            this.label178.ForeColor = System.Drawing.Color.White;
            this.label178.Location = new System.Drawing.Point(368, 2);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(50, 22);
            this.label178.TabIndex = 30;
            this.label178.Text = "° /";
            // 
            // label_FR_SlipRatio
            // 
            this.label_FR_SlipRatio.BackColor = System.Drawing.Color.Black;
            this.label_FR_SlipRatio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_SlipRatio.ForeColor = System.Drawing.Color.White;
            this.label_FR_SlipRatio.Location = new System.Drawing.Point(422, 2);
            this.label_FR_SlipRatio.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_SlipRatio.Name = "label_FR_SlipRatio";
            this.label_FR_SlipRatio.Size = new System.Drawing.Size(199, 22);
            this.label_FR_SlipRatio.TabIndex = 78;
            this.label_FR_SlipRatio.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Black;
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(625, 2);
            this.label28.MinimumSize = new System.Drawing.Size(0, 31);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(46, 31);
            this.label28.TabIndex = 33;
            this.label28.Text = "0-1";
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.Color.Black;
            this.label43.ForeColor = System.Drawing.Color.White;
            this.label43.Location = new System.Drawing.Point(421, 405);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(32, 25);
            this.label43.TabIndex = 30;
            this.label43.Tag = "LayoutIgnoredDuplicate";
            this.label43.Text = "° /";
            this.label43.Visible = false;
            // 
            // panel2TelemetryRow8
            // 
            this.panel2TelemetryRow8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow8.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow8.Controls.Add(this.label108);
            this.panel2TelemetryRow8.Controls.Add(this.label_FR_LateralFriction);
            this.panel2TelemetryRow8.Controls.Add(this.label179);
            this.panel2TelemetryRow8.Controls.Add(this.label_FR_LongitudinalFriction);
            this.panel2TelemetryRow8.Controls.Add(this.label27);
            this.panel2TelemetryRow8.Controls.Add(this.label42);
            this.panel2TelemetryRow8.Location = new System.Drawing.Point(4, 213);
            this.panel2TelemetryRow8.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow8.Name = "panel2TelemetryRow8";
            this.panel2TelemetryRow8.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow8.TabIndex = 8;
            // 
            // label108
            // 
            this.label108.ForeColor = System.Drawing.Color.White;
            this.label108.Location = new System.Drawing.Point(4, 2);
            this.label108.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label108.MinimumSize = new System.Drawing.Size(0, 31);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(158, 31);
            this.label108.TabIndex = 301;
            this.label108.Text = "Lat/Lon Friction";
            // 
            // label_FR_LateralFriction
            // 
            this.label_FR_LateralFriction.BackColor = System.Drawing.Color.Black;
            this.label_FR_LateralFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_LateralFriction.ForeColor = System.Drawing.Color.White;
            this.label_FR_LateralFriction.Location = new System.Drawing.Point(165, 2);
            this.label_FR_LateralFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_LateralFriction.Name = "label_FR_LateralFriction";
            this.label_FR_LateralFriction.Size = new System.Drawing.Size(208, 22);
            this.label_FR_LateralFriction.TabIndex = 81;
            this.label_FR_LateralFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label179
            // 
            this.label179.BackColor = System.Drawing.Color.Black;
            this.label179.ForeColor = System.Drawing.Color.White;
            this.label179.Location = new System.Drawing.Point(377, 2);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(50, 22);
            this.label179.TabIndex = 31;
            this.label179.Text = " /";
            // 
            // label_FR_LongitudinalFriction
            // 
            this.label_FR_LongitudinalFriction.BackColor = System.Drawing.Color.Black;
            this.label_FR_LongitudinalFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_LongitudinalFriction.ForeColor = System.Drawing.Color.White;
            this.label_FR_LongitudinalFriction.Location = new System.Drawing.Point(431, 2);
            this.label_FR_LongitudinalFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_LongitudinalFriction.Name = "label_FR_LongitudinalFriction";
            this.label_FR_LongitudinalFriction.Size = new System.Drawing.Size(208, 22);
            this.label_FR_LongitudinalFriction.TabIndex = 82;
            this.label_FR_LongitudinalFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Black;
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(643, 2);
            this.label27.MinimumSize = new System.Drawing.Size(0, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(27, 31);
            this.label27.TabIndex = 34;
            this.label27.Text = "μ";
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Black;
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(421, 455);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(24, 25);
            this.label42.TabIndex = 31;
            this.label42.Tag = "LayoutIgnoredDuplicate";
            this.label42.Text = " /";
            this.label42.Visible = false;
            // 
            // panel2TelemetryRow9
            // 
            this.panel2TelemetryRow9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow9.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow9.Controls.Add(this.label107);
            this.panel2TelemetryRow9.Controls.Add(this.label_FR_LateralSlipSpeed);
            this.panel2TelemetryRow9.Controls.Add(this.label180);
            this.panel2TelemetryRow9.Controls.Add(this.label_FR_LongitudinalSlipSpeed);
            this.panel2TelemetryRow9.Controls.Add(this.label26);
            this.panel2TelemetryRow9.Controls.Add(this.label41);
            this.panel2TelemetryRow9.Location = new System.Drawing.Point(4, 239);
            this.panel2TelemetryRow9.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow9.Name = "panel2TelemetryRow9";
            this.panel2TelemetryRow9.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow9.TabIndex = 9;
            // 
            // label107
            // 
            this.label107.ForeColor = System.Drawing.Color.White;
            this.label107.Location = new System.Drawing.Point(4, 2);
            this.label107.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label107.MinimumSize = new System.Drawing.Size(0, 31);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(158, 31);
            this.label107.TabIndex = 302;
            this.label107.Text = "Lat/Lon Slip Speed";
            // 
            // label_FR_LateralSlipSpeed
            // 
            this.label_FR_LateralSlipSpeed.BackColor = System.Drawing.Color.Black;
            this.label_FR_LateralSlipSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_LateralSlipSpeed.ForeColor = System.Drawing.Color.White;
            this.label_FR_LateralSlipSpeed.Location = new System.Drawing.Point(165, 2);
            this.label_FR_LateralSlipSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_LateralSlipSpeed.Name = "label_FR_LateralSlipSpeed";
            this.label_FR_LateralSlipSpeed.Size = new System.Drawing.Size(197, 22);
            this.label_FR_LateralSlipSpeed.TabIndex = 129;
            this.label_FR_LateralSlipSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label180
            // 
            this.label180.BackColor = System.Drawing.Color.Black;
            this.label180.ForeColor = System.Drawing.Color.White;
            this.label180.Location = new System.Drawing.Point(366, 2);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(50, 22);
            this.label180.TabIndex = 32;
            this.label180.Text = " /";
            // 
            // label_FR_LongitudinalSlipSpeed
            // 
            this.label_FR_LongitudinalSlipSpeed.BackColor = System.Drawing.Color.Black;
            this.label_FR_LongitudinalSlipSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_LongitudinalSlipSpeed.ForeColor = System.Drawing.Color.White;
            this.label_FR_LongitudinalSlipSpeed.Location = new System.Drawing.Point(420, 2);
            this.label_FR_LongitudinalSlipSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_LongitudinalSlipSpeed.Name = "label_FR_LongitudinalSlipSpeed";
            this.label_FR_LongitudinalSlipSpeed.Size = new System.Drawing.Size(197, 22);
            this.label_FR_LongitudinalSlipSpeed.TabIndex = 130;
            this.label_FR_LongitudinalSlipSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Black;
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(621, 2);
            this.label26.MinimumSize = new System.Drawing.Size(0, 31);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(49, 31);
            this.label26.TabIndex = 35;
            this.label26.Text = "m/s";
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.Black;
            this.label41.ForeColor = System.Drawing.Color.White;
            this.label41.Location = new System.Drawing.Point(421, 505);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(24, 25);
            this.label41.TabIndex = 32;
            this.label41.Tag = "LayoutIgnoredDuplicate";
            this.label41.Text = " /";
            this.label41.Visible = false;
            // 
            // panel2TelemetryRow10
            // 
            this.panel2TelemetryRow10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow10.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow10.Controls.Add(this.label106);
            this.panel2TelemetryRow10.Controls.Add(this.label_FR_TreadTemperature);
            this.panel2TelemetryRow10.Controls.Add(this.label181);
            this.panel2TelemetryRow10.Controls.Add(this.label_FR_InnerTemperature);
            this.panel2TelemetryRow10.Controls.Add(this.label25);
            this.panel2TelemetryRow10.Controls.Add(this.label40);
            this.panel2TelemetryRow10.Location = new System.Drawing.Point(4, 265);
            this.panel2TelemetryRow10.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow10.Name = "panel2TelemetryRow10";
            this.panel2TelemetryRow10.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow10.TabIndex = 10;
            // 
            // label106
            // 
            this.label106.ForeColor = System.Drawing.Color.White;
            this.label106.Location = new System.Drawing.Point(4, 2);
            this.label106.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label106.MinimumSize = new System.Drawing.Size(0, 31);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(158, 31);
            this.label106.TabIndex = 303;
            this.label106.Text = "Tread/Inner Temps";
            // 
            // label_FR_TreadTemperature
            // 
            this.label_FR_TreadTemperature.BackColor = System.Drawing.Color.Black;
            this.label_FR_TreadTemperature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_TreadTemperature.ForeColor = System.Drawing.Color.White;
            this.label_FR_TreadTemperature.Location = new System.Drawing.Point(165, 2);
            this.label_FR_TreadTemperature.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_TreadTemperature.Name = "label_FR_TreadTemperature";
            this.label_FR_TreadTemperature.Size = new System.Drawing.Size(203, 22);
            this.label_FR_TreadTemperature.TabIndex = 66;
            this.label_FR_TreadTemperature.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label181
            // 
            this.label181.BackColor = System.Drawing.Color.Black;
            this.label181.ForeColor = System.Drawing.Color.White;
            this.label181.Location = new System.Drawing.Point(372, 2);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(50, 22);
            this.label181.TabIndex = 33;
            this.label181.Text = "°C /";
            // 
            // label_FR_InnerTemperature
            // 
            this.label_FR_InnerTemperature.BackColor = System.Drawing.Color.Black;
            this.label_FR_InnerTemperature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_InnerTemperature.ForeColor = System.Drawing.Color.White;
            this.label_FR_InnerTemperature.Location = new System.Drawing.Point(426, 2);
            this.label_FR_InnerTemperature.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_InnerTemperature.Name = "label_FR_InnerTemperature";
            this.label_FR_InnerTemperature.Size = new System.Drawing.Size(203, 22);
            this.label_FR_InnerTemperature.TabIndex = 67;
            this.label_FR_InnerTemperature.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Black;
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(633, 2);
            this.label25.MinimumSize = new System.Drawing.Size(0, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 31);
            this.label25.TabIndex = 36;
            this.label25.Text = "°C";
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.Black;
            this.label40.ForeColor = System.Drawing.Color.White;
            this.label40.Location = new System.Drawing.Point(421, 555);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(47, 25);
            this.label40.TabIndex = 33;
            this.label40.Tag = "LayoutIgnoredDuplicate";
            this.label40.Text = "°C /";
            this.label40.Visible = false;
            // 
            // panel2TelemetryRow11
            // 
            this.panel2TelemetryRow11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow11.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow11.Controls.Add(this.label105);
            this.panel2TelemetryRow11.Controls.Add(this.label_FR_TotalFriction);
            this.panel2TelemetryRow11.Controls.Add(this.label182);
            this.panel2TelemetryRow11.Controls.Add(this.label_FR_TotalFrictionAngle);
            this.panel2TelemetryRow11.Controls.Add(this.label24);
            this.panel2TelemetryRow11.Controls.Add(this.label39);
            this.panel2TelemetryRow11.Location = new System.Drawing.Point(4, 291);
            this.panel2TelemetryRow11.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow11.Name = "panel2TelemetryRow11";
            this.panel2TelemetryRow11.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow11.TabIndex = 11;
            // 
            // label105
            // 
            this.label105.ForeColor = System.Drawing.Color.White;
            this.label105.Location = new System.Drawing.Point(4, 2);
            this.label105.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label105.MinimumSize = new System.Drawing.Size(0, 31);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(158, 31);
            this.label105.TabIndex = 304;
            this.label105.Text = "Total Friction/Angle";
            // 
            // label_FR_TotalFriction
            // 
            this.label_FR_TotalFriction.BackColor = System.Drawing.Color.Black;
            this.label_FR_TotalFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_TotalFriction.ForeColor = System.Drawing.Color.White;
            this.label_FR_TotalFriction.Location = new System.Drawing.Point(165, 2);
            this.label_FR_TotalFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_TotalFriction.Name = "label_FR_TotalFriction";
            this.label_FR_TotalFriction.Size = new System.Drawing.Size(210, 22);
            this.label_FR_TotalFriction.TabIndex = 143;
            this.label_FR_TotalFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label182
            // 
            this.label182.BackColor = System.Drawing.Color.Black;
            this.label182.ForeColor = System.Drawing.Color.White;
            this.label182.Location = new System.Drawing.Point(379, 2);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(50, 22);
            this.label182.TabIndex = 34;
            this.label182.Text = "μ /";
            // 
            // label_FR_TotalFrictionAngle
            // 
            this.label_FR_TotalFrictionAngle.BackColor = System.Drawing.Color.Black;
            this.label_FR_TotalFrictionAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_TotalFrictionAngle.ForeColor = System.Drawing.Color.White;
            this.label_FR_TotalFrictionAngle.Location = new System.Drawing.Point(433, 2);
            this.label_FR_TotalFrictionAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_TotalFrictionAngle.Name = "label_FR_TotalFrictionAngle";
            this.label_FR_TotalFrictionAngle.Size = new System.Drawing.Size(210, 22);
            this.label_FR_TotalFrictionAngle.TabIndex = 144;
            this.label_FR_TotalFrictionAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(647, 2);
            this.label24.MinimumSize = new System.Drawing.Size(0, 31);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(23, 31);
            this.label24.TabIndex = 37;
            this.label24.Text = "°";
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.Black;
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(421, 605);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(36, 25);
            this.label39.TabIndex = 34;
            this.label39.Tag = "LayoutIgnoredDuplicate";
            this.label39.Text = "μ /";
            this.label39.Visible = false;
            // 
            // panel2TelemetryRow12
            // 
            this.panel2TelemetryRow12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow12.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow12.Controls.Add(this.label104);
            this.panel2TelemetryRow12.Controls.Add(this.label_FR_SuspensionLength);
            this.panel2TelemetryRow12.Controls.Add(this.label183);
            this.panel2TelemetryRow12.Controls.Add(this.label_FR_SuspensionVelocity);
            this.panel2TelemetryRow12.Controls.Add(this.label21);
            this.panel2TelemetryRow12.Controls.Add(this.label36);
            this.panel2TelemetryRow12.Location = new System.Drawing.Point(4, 317);
            this.panel2TelemetryRow12.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow12.Name = "panel2TelemetryRow12";
            this.panel2TelemetryRow12.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow12.TabIndex = 12;
            // 
            // label104
            // 
            this.label104.ForeColor = System.Drawing.Color.White;
            this.label104.Location = new System.Drawing.Point(4, 2);
            this.label104.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label104.MinimumSize = new System.Drawing.Size(0, 31);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(158, 31);
            this.label104.TabIndex = 305;
            this.label104.Text = "Susp Length/Velocity";
            // 
            // label_FR_SuspensionLength
            // 
            this.label_FR_SuspensionLength.BackColor = System.Drawing.Color.Black;
            this.label_FR_SuspensionLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_SuspensionLength.ForeColor = System.Drawing.Color.White;
            this.label_FR_SuspensionLength.Location = new System.Drawing.Point(165, 2);
            this.label_FR_SuspensionLength.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_SuspensionLength.Name = "label_FR_SuspensionLength";
            this.label_FR_SuspensionLength.Size = new System.Drawing.Size(197, 22);
            this.label_FR_SuspensionLength.TabIndex = 231;
            this.label_FR_SuspensionLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label183
            // 
            this.label183.BackColor = System.Drawing.Color.Black;
            this.label183.ForeColor = System.Drawing.Color.White;
            this.label183.Location = new System.Drawing.Point(366, 2);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(50, 22);
            this.label183.TabIndex = 35;
            this.label183.Text = "m /";
            // 
            // label_FR_SuspensionVelocity
            // 
            this.label_FR_SuspensionVelocity.BackColor = System.Drawing.Color.Black;
            this.label_FR_SuspensionVelocity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_SuspensionVelocity.ForeColor = System.Drawing.Color.White;
            this.label_FR_SuspensionVelocity.Location = new System.Drawing.Point(420, 2);
            this.label_FR_SuspensionVelocity.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_SuspensionVelocity.Name = "label_FR_SuspensionVelocity";
            this.label_FR_SuspensionVelocity.Size = new System.Drawing.Size(197, 22);
            this.label_FR_SuspensionVelocity.TabIndex = 232;
            this.label_FR_SuspensionVelocity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Black;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(621, 2);
            this.label21.MinimumSize = new System.Drawing.Size(0, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 31);
            this.label21.TabIndex = 38;
            this.label21.Text = "m/s";
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Black;
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(421, 657);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(41, 25);
            this.label36.TabIndex = 35;
            this.label36.Tag = "LayoutIgnoredDuplicate";
            this.label36.Text = "m /";
            this.label36.Visible = false;
            // 
            // panel2TelemetryRow13
            // 
            this.panel2TelemetryRow13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow13.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow13.Controls.Add(this.label111);
            this.panel2TelemetryRow13.Controls.Add(this.label_FR_TireSteerAngle);
            this.panel2TelemetryRow13.Controls.Add(this.label184);
            this.panel2TelemetryRow13.Controls.Add(this.label_FR_CamberAngle);
            this.panel2TelemetryRow13.Controls.Add(this.label20);
            this.panel2TelemetryRow13.Controls.Add(this.label35);
            this.panel2TelemetryRow13.Location = new System.Drawing.Point(4, 343);
            this.panel2TelemetryRow13.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow13.Name = "panel2TelemetryRow13";
            this.panel2TelemetryRow13.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow13.TabIndex = 13;
            // 
            // label111
            // 
            this.label111.ForeColor = System.Drawing.Color.White;
            this.label111.Location = new System.Drawing.Point(4, 2);
            this.label111.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label111.MinimumSize = new System.Drawing.Size(0, 31);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(158, 31);
            this.label111.TabIndex = 298;
            this.label111.Text = "Steer/Camber Angle";
            // 
            // label_FR_TireSteerAngle
            // 
            this.label_FR_TireSteerAngle.BackColor = System.Drawing.Color.Black;
            this.label_FR_TireSteerAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_TireSteerAngle.ForeColor = System.Drawing.Color.White;
            this.label_FR_TireSteerAngle.Location = new System.Drawing.Point(165, 2);
            this.label_FR_TireSteerAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_TireSteerAngle.Name = "label_FR_TireSteerAngle";
            this.label_FR_TireSteerAngle.Size = new System.Drawing.Size(210, 22);
            this.label_FR_TireSteerAngle.TabIndex = 131;
            this.label_FR_TireSteerAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label184
            // 
            this.label184.BackColor = System.Drawing.Color.Black;
            this.label184.ForeColor = System.Drawing.Color.White;
            this.label184.Location = new System.Drawing.Point(379, 2);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(50, 22);
            this.label184.TabIndex = 36;
            this.label184.Text = " /";
            // 
            // label_FR_CamberAngle
            // 
            this.label_FR_CamberAngle.BackColor = System.Drawing.Color.Black;
            this.label_FR_CamberAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_CamberAngle.ForeColor = System.Drawing.Color.White;
            this.label_FR_CamberAngle.Location = new System.Drawing.Point(433, 2);
            this.label_FR_CamberAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_CamberAngle.Name = "label_FR_CamberAngle";
            this.label_FR_CamberAngle.Size = new System.Drawing.Size(210, 22);
            this.label_FR_CamberAngle.TabIndex = 132;
            this.label_FR_CamberAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(647, 2);
            this.label20.MinimumSize = new System.Drawing.Size(0, 31);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 31);
            this.label20.TabIndex = 39;
            this.label20.Text = "°";
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Black;
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(421, 705);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(24, 25);
            this.label35.TabIndex = 36;
            this.label35.Tag = "LayoutIgnoredDuplicate";
            this.label35.Text = " /";
            this.label35.Visible = false;
            // 
            // panel2TelemetryRow14
            // 
            this.panel2TelemetryRow14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow14.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow14.Controls.Add(this.label187);
            this.panel2TelemetryRow14.Controls.Add(this.label_FR_Mx);
            this.panel2TelemetryRow14.Controls.Add(this.label186);
            this.panel2TelemetryRow14.Controls.Add(this.label_FR_Mz);
            this.panel2TelemetryRow14.Controls.Add(this.label185);
            this.panel2TelemetryRow14.Controls.Add(this.label_FR_My);
            this.panel2TelemetryRow14.Location = new System.Drawing.Point(4, 369);
            this.panel2TelemetryRow14.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow14.Name = "panel2TelemetryRow14";
            this.panel2TelemetryRow14.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow14.TabIndex = 14;
            // 
            // label187
            // 
            this.label187.ForeColor = System.Drawing.Color.White;
            this.label187.Location = new System.Drawing.Point(4, 2);
            this.label187.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label187.MinimumSize = new System.Drawing.Size(0, 31);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(158, 31);
            this.label187.TabIndex = 239;
            this.label187.Text = "Mx/Mz/My";
            // 
            // label_FR_Mx
            // 
            this.label_FR_Mx.BackColor = System.Drawing.Color.Black;
            this.label_FR_Mx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_Mx.ForeColor = System.Drawing.Color.White;
            this.label_FR_Mx.Location = new System.Drawing.Point(165, 2);
            this.label_FR_Mx.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_Mx.Name = "label_FR_Mx";
            this.label_FR_Mx.Size = new System.Drawing.Size(145, 22);
            this.label_FR_Mx.TabIndex = 236;
            this.label_FR_Mx.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label186
            // 
            this.label186.BackColor = System.Drawing.Color.Black;
            this.label186.ForeColor = System.Drawing.Color.White;
            this.label186.Location = new System.Drawing.Point(314, 2);
            this.label186.MinimumSize = new System.Drawing.Size(0, 31);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(27, 31);
            this.label186.TabIndex = 240;
            this.label186.Text = " /";
            // 
            // label_FR_Mz
            // 
            this.label_FR_Mz.BackColor = System.Drawing.Color.Black;
            this.label_FR_Mz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_Mz.ForeColor = System.Drawing.Color.White;
            this.label_FR_Mz.Location = new System.Drawing.Point(345, 2);
            this.label_FR_Mz.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_Mz.Name = "label_FR_Mz";
            this.label_FR_Mz.Size = new System.Drawing.Size(145, 22);
            this.label_FR_Mz.TabIndex = 237;
            this.label_FR_Mz.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label185
            // 
            this.label185.BackColor = System.Drawing.Color.Black;
            this.label185.ForeColor = System.Drawing.Color.White;
            this.label185.Location = new System.Drawing.Point(494, 2);
            this.label185.MinimumSize = new System.Drawing.Size(0, 31);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(27, 31);
            this.label185.TabIndex = 241;
            this.label185.Text = " /";
            // 
            // label_FR_My
            // 
            this.label_FR_My.BackColor = System.Drawing.Color.Black;
            this.label_FR_My.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_My.ForeColor = System.Drawing.Color.White;
            this.label_FR_My.Location = new System.Drawing.Point(525, 2);
            this.label_FR_My.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_My.Name = "label_FR_My";
            this.label_FR_My.Size = new System.Drawing.Size(145, 22);
            this.label_FR_My.TabIndex = 238;
            this.label_FR_My.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2TelemetryRow15
            // 
            this.panel2TelemetryRow15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2TelemetryRow15.BackColor = System.Drawing.Color.Black;
            this.panel2TelemetryRow15.Controls.Add(this.label198);
            this.panel2TelemetryRow15.Controls.Add(this.label_FR_PneumaticTrail);
            this.panel2TelemetryRow15.Controls.Add(this.label192);
            this.panel2TelemetryRow15.Controls.Add(this.label_FR_RollingResistance);
            this.panel2TelemetryRow15.Location = new System.Drawing.Point(4, 395);
            this.panel2TelemetryRow15.Margin = new System.Windows.Forms.Padding(0);
            this.panel2TelemetryRow15.Name = "panel2TelemetryRow15";
            this.panel2TelemetryRow15.Size = new System.Drawing.Size(436, 24);
            this.panel2TelemetryRow15.TabIndex = 15;
            // 
            // label198
            // 
            this.label198.ForeColor = System.Drawing.Color.White;
            this.label198.Location = new System.Drawing.Point(4, 2);
            this.label198.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label198.MinimumSize = new System.Drawing.Size(0, 31);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(158, 31);
            this.label198.TabIndex = 239;
            this.label198.Text = "Pt/Rr";
            // 
            // label_FR_PneumaticTrail
            // 
            this.label_FR_PneumaticTrail.BackColor = System.Drawing.Color.Black;
            this.label_FR_PneumaticTrail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_PneumaticTrail.ForeColor = System.Drawing.Color.White;
            this.label_FR_PneumaticTrail.Location = new System.Drawing.Point(165, 2);
            this.label_FR_PneumaticTrail.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_PneumaticTrail.Name = "label_FR_PneumaticTrail";
            this.label_FR_PneumaticTrail.Size = new System.Drawing.Size(220, 22);
            this.label_FR_PneumaticTrail.TabIndex = 240;
            this.label_FR_PneumaticTrail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label192
            // 
            this.label192.BackColor = System.Drawing.Color.Black;
            this.label192.ForeColor = System.Drawing.Color.White;
            this.label192.Location = new System.Drawing.Point(389, 2);
            this.label192.MinimumSize = new System.Drawing.Size(0, 31);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(44, 31);
            this.label192.TabIndex = 241;
            this.label192.Text = "m /";
            // 
            // label_FR_RollingResistance
            // 
            this.label_FR_RollingResistance.BackColor = System.Drawing.Color.Black;
            this.label_FR_RollingResistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_FR_RollingResistance.ForeColor = System.Drawing.Color.White;
            this.label_FR_RollingResistance.Location = new System.Drawing.Point(437, 2);
            this.label_FR_RollingResistance.Margin = new System.Windows.Forms.Padding(6);
            this.label_FR_RollingResistance.Name = "label_FR_RollingResistance";
            this.label_FR_RollingResistance.Size = new System.Drawing.Size(220, 22);
            this.label_FR_RollingResistance.TabIndex = 241;
            this.label_FR_RollingResistance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel3TelemetryCard
            // 
            this.panel3TelemetryCard.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryCard.Controls.Add(this.panel3);
            this.panel3TelemetryCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3TelemetryCard.ForeColor = System.Drawing.Color.White;
            this.panel3TelemetryCard.Location = new System.Drawing.Point(3, 451);
            this.panel3TelemetryCard.Name = "panel3TelemetryCard";
            this.panel3TelemetryCard.Padding = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.panel3TelemetryCard.Size = new System.Drawing.Size(594, 442);
            this.panel3TelemetryCard.TabIndex = 2;
            this.panel3TelemetryCard.TabStop = false;
            this.panel3TelemetryCard.Text = "REAR LEFT DATA";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.panel3TelemetryRow0);
            this.panel3.Controls.Add(this.panel3TelemetryRow1);
            this.panel3.Controls.Add(this.panel3TelemetryRow2);
            this.panel3.Controls.Add(this.panel3TelemetryRow3);
            this.panel3.Controls.Add(this.panel3TelemetryRow4);
            this.panel3.Controls.Add(this.panel3TelemetryRow5);
            this.panel3.Controls.Add(this.panel3TelemetryRow6);
            this.panel3.Controls.Add(this.panel3TelemetryRow7);
            this.panel3.Controls.Add(this.panel3TelemetryRow8);
            this.panel3.Controls.Add(this.panel3TelemetryRow9);
            this.panel3.Controls.Add(this.panel3TelemetryRow10);
            this.panel3.Controls.Add(this.panel3TelemetryRow11);
            this.panel3.Controls.Add(this.panel3TelemetryRow12);
            this.panel3.Controls.Add(this.panel3TelemetryRow13);
            this.panel3.Controls.Add(this.panel3TelemetryRow14);
            this.panel3.Controls.Add(this.panel3TelemetryRow15);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 39);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(588, 400);
            this.panel3.TabIndex = 290;
            // 
            // panel3TelemetryRow0
            // 
            this.panel3TelemetryRow0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow0.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow0.Controls.Add(this.label131);
            this.panel3TelemetryRow0.Controls.Add(this.label_RL_TravelSpeed);
            this.panel3TelemetryRow0.Controls.Add(this.label159);
            this.panel3TelemetryRow0.Location = new System.Drawing.Point(4, 5);
            this.panel3TelemetryRow0.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow0.Name = "panel3TelemetryRow0";
            this.panel3TelemetryRow0.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow0.TabIndex = 0;
            // 
            // label131
            // 
            this.label131.ForeColor = System.Drawing.Color.White;
            this.label131.Location = new System.Drawing.Point(4, 2);
            this.label131.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label131.MinimumSize = new System.Drawing.Size(0, 31);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(158, 31);
            this.label131.TabIndex = 306;
            this.label131.Text = "Tire Travel Speed\r\n";
            // 
            // label_RL_TravelSpeed
            // 
            this.label_RL_TravelSpeed.BackColor = System.Drawing.Color.Black;
            this.label_RL_TravelSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_TravelSpeed.ForeColor = System.Drawing.Color.White;
            this.label_RL_TravelSpeed.Location = new System.Drawing.Point(165, 2);
            this.label_RL_TravelSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_TravelSpeed.Name = "label_RL_TravelSpeed";
            this.label_RL_TravelSpeed.Size = new System.Drawing.Size(220, 22);
            this.label_RL_TravelSpeed.TabIndex = 99;
            this.label_RL_TravelSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label159
            // 
            this.label159.BackColor = System.Drawing.Color.Black;
            this.label159.ForeColor = System.Drawing.Color.White;
            this.label159.Location = new System.Drawing.Point(389, 2);
            this.label159.MinimumSize = new System.Drawing.Size(0, 31);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(49, 31);
            this.label159.TabIndex = 26;
            this.label159.Text = "m/s";
            // 
            // panel3TelemetryRow1
            // 
            this.panel3TelemetryRow1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow1.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow1.Controls.Add(this.label130);
            this.panel3TelemetryRow1.Controls.Add(this.label_RL_AngularVelocity);
            this.panel3TelemetryRow1.Controls.Add(this.label158);
            this.panel3TelemetryRow1.Location = new System.Drawing.Point(4, 31);
            this.panel3TelemetryRow1.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow1.Name = "panel3TelemetryRow1";
            this.panel3TelemetryRow1.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow1.TabIndex = 1;
            // 
            // label130
            // 
            this.label130.ForeColor = System.Drawing.Color.White;
            this.label130.Location = new System.Drawing.Point(4, 2);
            this.label130.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label130.MinimumSize = new System.Drawing.Size(0, 31);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(158, 31);
            this.label130.TabIndex = 307;
            this.label130.Text = "Angular Velocity";
            // 
            // label_RL_AngularVelocity
            // 
            this.label_RL_AngularVelocity.BackColor = System.Drawing.Color.Black;
            this.label_RL_AngularVelocity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_AngularVelocity.ForeColor = System.Drawing.Color.White;
            this.label_RL_AngularVelocity.Location = new System.Drawing.Point(165, 2);
            this.label_RL_AngularVelocity.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_AngularVelocity.Name = "label_RL_AngularVelocity";
            this.label_RL_AngularVelocity.Size = new System.Drawing.Size(220, 22);
            this.label_RL_AngularVelocity.TabIndex = 84;
            this.label_RL_AngularVelocity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label158
            // 
            this.label158.BackColor = System.Drawing.Color.Black;
            this.label158.ForeColor = System.Drawing.Color.White;
            this.label158.Location = new System.Drawing.Point(389, 2);
            this.label158.MinimumSize = new System.Drawing.Size(0, 31);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(60, 31);
            this.label158.TabIndex = 27;
            this.label158.Text = "km/h";
            // 
            // panel3TelemetryRow2
            // 
            this.panel3TelemetryRow2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow2.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow2.Controls.Add(this.label129);
            this.panel3TelemetryRow2.Controls.Add(this.label_RL_VerticalLoad);
            this.panel3TelemetryRow2.Controls.Add(this.label60);
            this.panel3TelemetryRow2.Controls.Add(this.label_RL_Deflection);
            this.panel3TelemetryRow2.Controls.Add(this.label157);
            this.panel3TelemetryRow2.Location = new System.Drawing.Point(4, 57);
            this.panel3TelemetryRow2.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow2.Name = "panel3TelemetryRow2";
            this.panel3TelemetryRow2.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow2.TabIndex = 2;
            // 
            // label129
            // 
            this.label129.ForeColor = System.Drawing.Color.White;
            this.label129.Location = new System.Drawing.Point(4, 2);
            this.label129.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label129.MinimumSize = new System.Drawing.Size(0, 31);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(158, 31);
            this.label129.TabIndex = 308;
            this.label129.Text = "Vertical Load/Deflection";
            // 
            // label_RL_VerticalLoad
            // 
            this.label_RL_VerticalLoad.BackColor = System.Drawing.Color.Black;
            this.label_RL_VerticalLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_VerticalLoad.ForeColor = System.Drawing.Color.White;
            this.label_RL_VerticalLoad.Location = new System.Drawing.Point(165, 2);
            this.label_RL_VerticalLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_VerticalLoad.Name = "label_RL_VerticalLoad";
            this.label_RL_VerticalLoad.Size = new System.Drawing.Size(210, 22);
            this.label_RL_VerticalLoad.TabIndex = 92;
            this.label_RL_VerticalLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.Black;
            this.label60.ForeColor = System.Drawing.Color.White;
            this.label60.Location = new System.Drawing.Point(379, 2);
            this.label60.MinimumSize = new System.Drawing.Size(0, 31);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(42, 31);
            this.label60.TabIndex = 40;
            this.label60.Text = "N /";
            // 
            // label_RL_Deflection
            // 
            this.label_RL_Deflection.BackColor = System.Drawing.Color.Black;
            this.label_RL_Deflection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_Deflection.ForeColor = System.Drawing.Color.White;
            this.label_RL_Deflection.Location = new System.Drawing.Point(425, 2);
            this.label_RL_Deflection.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_Deflection.Name = "label_RL_Deflection";
            this.label_RL_Deflection.Size = new System.Drawing.Size(210, 22);
            this.label_RL_Deflection.TabIndex = 87;
            this.label_RL_Deflection.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label157
            // 
            this.label157.BackColor = System.Drawing.Color.Black;
            this.label157.ForeColor = System.Drawing.Color.White;
            this.label157.Location = new System.Drawing.Point(639, 2);
            this.label157.MinimumSize = new System.Drawing.Size(0, 31);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(32, 31);
            this.label157.TabIndex = 28;
            this.label157.Text = "m";
            // 
            // panel3TelemetryRow3
            // 
            this.panel3TelemetryRow3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow3.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow3.Controls.Add(this.label128);
            this.panel3TelemetryRow3.Controls.Add(this.label_RL_LoadedRadius);
            this.panel3TelemetryRow3.Controls.Add(this.label59);
            this.panel3TelemetryRow3.Controls.Add(this.label_RL_EffectiveRadius);
            this.panel3TelemetryRow3.Controls.Add(this.label156);
            this.panel3TelemetryRow3.Location = new System.Drawing.Point(4, 83);
            this.panel3TelemetryRow3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow3.Name = "panel3TelemetryRow3";
            this.panel3TelemetryRow3.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow3.TabIndex = 3;
            // 
            // label128
            // 
            this.label128.ForeColor = System.Drawing.Color.White;
            this.label128.Location = new System.Drawing.Point(4, 2);
            this.label128.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label128.MinimumSize = new System.Drawing.Size(0, 31);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(158, 31);
            this.label128.TabIndex = 309;
            this.label128.Text = "Loaded/Effective Radius";
            // 
            // label_RL_LoadedRadius
            // 
            this.label_RL_LoadedRadius.BackColor = System.Drawing.Color.Black;
            this.label_RL_LoadedRadius.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_LoadedRadius.ForeColor = System.Drawing.Color.White;
            this.label_RL_LoadedRadius.Location = new System.Drawing.Point(165, 2);
            this.label_RL_LoadedRadius.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_LoadedRadius.Name = "label_RL_LoadedRadius";
            this.label_RL_LoadedRadius.Size = new System.Drawing.Size(209, 22);
            this.label_RL_LoadedRadius.TabIndex = 88;
            this.label_RL_LoadedRadius.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.Black;
            this.label59.ForeColor = System.Drawing.Color.White;
            this.label59.Location = new System.Drawing.Point(378, 2);
            this.label59.MinimumSize = new System.Drawing.Size(0, 31);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(44, 31);
            this.label59.TabIndex = 41;
            this.label59.Text = "m /";
            // 
            // label_RL_EffectiveRadius
            // 
            this.label_RL_EffectiveRadius.BackColor = System.Drawing.Color.Black;
            this.label_RL_EffectiveRadius.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_EffectiveRadius.ForeColor = System.Drawing.Color.White;
            this.label_RL_EffectiveRadius.Location = new System.Drawing.Point(426, 2);
            this.label_RL_EffectiveRadius.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_EffectiveRadius.Name = "label_RL_EffectiveRadius";
            this.label_RL_EffectiveRadius.Size = new System.Drawing.Size(209, 22);
            this.label_RL_EffectiveRadius.TabIndex = 89;
            this.label_RL_EffectiveRadius.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label156
            // 
            this.label156.BackColor = System.Drawing.Color.Black;
            this.label156.ForeColor = System.Drawing.Color.White;
            this.label156.Location = new System.Drawing.Point(639, 2);
            this.label156.MinimumSize = new System.Drawing.Size(0, 31);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(32, 31);
            this.label156.TabIndex = 29;
            this.label156.Text = "m";
            // 
            // panel3TelemetryRow4
            // 
            this.panel3TelemetryRow4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow4.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow4.Controls.Add(this.label127);
            this.panel3TelemetryRow4.Controls.Add(this.label_RL_ContactLength);
            this.panel3TelemetryRow4.Controls.Add(this.label155);
            this.panel3TelemetryRow4.Location = new System.Drawing.Point(4, 109);
            this.panel3TelemetryRow4.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow4.Name = "panel3TelemetryRow4";
            this.panel3TelemetryRow4.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow4.TabIndex = 4;
            // 
            // label127
            // 
            this.label127.ForeColor = System.Drawing.Color.White;
            this.label127.Location = new System.Drawing.Point(4, 2);
            this.label127.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label127.MinimumSize = new System.Drawing.Size(0, 31);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(158, 31);
            this.label127.TabIndex = 310;
            this.label127.Text = "Contact Length";
            // 
            // label_RL_ContactLength
            // 
            this.label_RL_ContactLength.BackColor = System.Drawing.Color.Black;
            this.label_RL_ContactLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_ContactLength.ForeColor = System.Drawing.Color.White;
            this.label_RL_ContactLength.Location = new System.Drawing.Point(165, 2);
            this.label_RL_ContactLength.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_ContactLength.Name = "label_RL_ContactLength";
            this.label_RL_ContactLength.Size = new System.Drawing.Size(220, 22);
            this.label_RL_ContactLength.TabIndex = 98;
            this.label_RL_ContactLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label155
            // 
            this.label155.BackColor = System.Drawing.Color.Black;
            this.label155.ForeColor = System.Drawing.Color.White;
            this.label155.Location = new System.Drawing.Point(389, 2);
            this.label155.MinimumSize = new System.Drawing.Size(0, 31);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(32, 31);
            this.label155.TabIndex = 30;
            this.label155.Text = "m";
            // 
            // panel3TelemetryRow5
            // 
            this.panel3TelemetryRow5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow5.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow5.Controls.Add(this.label126);
            this.panel3TelemetryRow5.Controls.Add(this.label_RL_CurrentContactBrakeTorque);
            this.panel3TelemetryRow5.Controls.Add(this.label58);
            this.panel3TelemetryRow5.Controls.Add(this.label_RL_MaxCurrentContactBrakeTorque);
            this.panel3TelemetryRow5.Controls.Add(this.label154);
            this.panel3TelemetryRow5.Location = new System.Drawing.Point(4, 135);
            this.panel3TelemetryRow5.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow5.Name = "panel3TelemetryRow5";
            this.panel3TelemetryRow5.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow5.TabIndex = 5;
            // 
            // label126
            // 
            this.label126.ForeColor = System.Drawing.Color.White;
            this.label126.Location = new System.Drawing.Point(4, 2);
            this.label126.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label126.MinimumSize = new System.Drawing.Size(0, 31);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(158, 31);
            this.label126.TabIndex = 311;
            this.label126.Text = "Braking Torque";
            // 
            // label_RL_CurrentContactBrakeTorque
            // 
            this.label_RL_CurrentContactBrakeTorque.BackColor = System.Drawing.Color.Black;
            this.label_RL_CurrentContactBrakeTorque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_CurrentContactBrakeTorque.ForeColor = System.Drawing.Color.White;
            this.label_RL_CurrentContactBrakeTorque.Location = new System.Drawing.Point(165, 2);
            this.label_RL_CurrentContactBrakeTorque.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_CurrentContactBrakeTorque.Name = "label_RL_CurrentContactBrakeTorque";
            this.label_RL_CurrentContactBrakeTorque.Size = new System.Drawing.Size(210, 22);
            this.label_RL_CurrentContactBrakeTorque.TabIndex = 90;
            this.label_RL_CurrentContactBrakeTorque.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.Black;
            this.label58.ForeColor = System.Drawing.Color.White;
            this.label58.Location = new System.Drawing.Point(379, 2);
            this.label58.MinimumSize = new System.Drawing.Size(0, 31);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(27, 31);
            this.label58.TabIndex = 42;
            this.label58.Text = " /";
            // 
            // label_RL_MaxCurrentContactBrakeTorque
            // 
            this.label_RL_MaxCurrentContactBrakeTorque.BackColor = System.Drawing.Color.Black;
            this.label_RL_MaxCurrentContactBrakeTorque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_MaxCurrentContactBrakeTorque.ForeColor = System.Drawing.Color.White;
            this.label_RL_MaxCurrentContactBrakeTorque.Location = new System.Drawing.Point(410, 2);
            this.label_RL_MaxCurrentContactBrakeTorque.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_MaxCurrentContactBrakeTorque.Name = "label_RL_MaxCurrentContactBrakeTorque";
            this.label_RL_MaxCurrentContactBrakeTorque.Size = new System.Drawing.Size(210, 22);
            this.label_RL_MaxCurrentContactBrakeTorque.TabIndex = 153;
            this.label_RL_MaxCurrentContactBrakeTorque.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label154
            // 
            this.label154.BackColor = System.Drawing.Color.Black;
            this.label154.ForeColor = System.Drawing.Color.White;
            this.label154.Location = new System.Drawing.Point(624, 2);
            this.label154.MinimumSize = new System.Drawing.Size(0, 31);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(47, 31);
            this.label154.TabIndex = 31;
            this.label154.Text = "Nm";
            // 
            // panel3TelemetryRow6
            // 
            this.panel3TelemetryRow6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow6.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow6.Controls.Add(this.label124);
            this.panel3TelemetryRow6.Controls.Add(this.label_RL_LateralLoad);
            this.panel3TelemetryRow6.Controls.Add(this.label57);
            this.panel3TelemetryRow6.Controls.Add(this.label_RL_LongitudinalLoad);
            this.panel3TelemetryRow6.Controls.Add(this.label153);
            this.panel3TelemetryRow6.Location = new System.Drawing.Point(4, 161);
            this.panel3TelemetryRow6.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow6.Name = "panel3TelemetryRow6";
            this.panel3TelemetryRow6.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow6.TabIndex = 6;
            // 
            // label124
            // 
            this.label124.ForeColor = System.Drawing.Color.White;
            this.label124.Location = new System.Drawing.Point(4, 2);
            this.label124.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label124.MinimumSize = new System.Drawing.Size(0, 31);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(158, 31);
            this.label124.TabIndex = 313;
            this.label124.Text = "Lat/Lon Load";
            // 
            // label_RL_LateralLoad
            // 
            this.label_RL_LateralLoad.BackColor = System.Drawing.Color.Black;
            this.label_RL_LateralLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_LateralLoad.ForeColor = System.Drawing.Color.White;
            this.label_RL_LateralLoad.Location = new System.Drawing.Point(165, 2);
            this.label_RL_LateralLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_LateralLoad.Name = "label_RL_LateralLoad";
            this.label_RL_LateralLoad.Size = new System.Drawing.Size(218, 22);
            this.label_RL_LateralLoad.TabIndex = 93;
            this.label_RL_LateralLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.Black;
            this.label57.ForeColor = System.Drawing.Color.White;
            this.label57.Location = new System.Drawing.Point(387, 2);
            this.label57.MinimumSize = new System.Drawing.Size(0, 31);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(27, 31);
            this.label57.TabIndex = 43;
            this.label57.Text = " /";
            // 
            // label_RL_LongitudinalLoad
            // 
            this.label_RL_LongitudinalLoad.BackColor = System.Drawing.Color.Black;
            this.label_RL_LongitudinalLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_LongitudinalLoad.ForeColor = System.Drawing.Color.White;
            this.label_RL_LongitudinalLoad.Location = new System.Drawing.Point(418, 2);
            this.label_RL_LongitudinalLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_LongitudinalLoad.Name = "label_RL_LongitudinalLoad";
            this.label_RL_LongitudinalLoad.Size = new System.Drawing.Size(218, 22);
            this.label_RL_LongitudinalLoad.TabIndex = 94;
            this.label_RL_LongitudinalLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label153
            // 
            this.label153.BackColor = System.Drawing.Color.Black;
            this.label153.ForeColor = System.Drawing.Color.White;
            this.label153.Location = new System.Drawing.Point(640, 2);
            this.label153.MinimumSize = new System.Drawing.Size(0, 31);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(30, 31);
            this.label153.TabIndex = 32;
            this.label153.Text = "N";
            // 
            // panel3TelemetryRow7
            // 
            this.panel3TelemetryRow7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow7.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow7.Controls.Add(this.label123);
            this.panel3TelemetryRow7.Controls.Add(this.label_RL_SlipAngleDeg);
            this.panel3TelemetryRow7.Controls.Add(this.label56);
            this.panel3TelemetryRow7.Controls.Add(this.label_RL_SlipRatio);
            this.panel3TelemetryRow7.Controls.Add(this.label152);
            this.panel3TelemetryRow7.Location = new System.Drawing.Point(4, 187);
            this.panel3TelemetryRow7.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow7.Name = "panel3TelemetryRow7";
            this.panel3TelemetryRow7.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow7.TabIndex = 7;
            // 
            // label123
            // 
            this.label123.ForeColor = System.Drawing.Color.White;
            this.label123.Location = new System.Drawing.Point(4, 2);
            this.label123.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label123.MinimumSize = new System.Drawing.Size(0, 31);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(158, 31);
            this.label123.TabIndex = 314;
            this.label123.Text = "Slip Angle/Ratio";
            // 
            // label_RL_SlipAngleDeg
            // 
            this.label_RL_SlipAngleDeg.BackColor = System.Drawing.Color.Black;
            this.label_RL_SlipAngleDeg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_SlipAngleDeg.ForeColor = System.Drawing.Color.White;
            this.label_RL_SlipAngleDeg.Location = new System.Drawing.Point(165, 2);
            this.label_RL_SlipAngleDeg.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_SlipAngleDeg.Name = "label_RL_SlipAngleDeg";
            this.label_RL_SlipAngleDeg.Size = new System.Drawing.Size(206, 22);
            this.label_RL_SlipAngleDeg.TabIndex = 96;
            this.label_RL_SlipAngleDeg.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.Black;
            this.label56.ForeColor = System.Drawing.Color.White;
            this.label56.Location = new System.Drawing.Point(375, 2);
            this.label56.MinimumSize = new System.Drawing.Size(0, 31);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(35, 31);
            this.label56.TabIndex = 44;
            this.label56.Text = "° /";
            // 
            // label_RL_SlipRatio
            // 
            this.label_RL_SlipRatio.BackColor = System.Drawing.Color.Black;
            this.label_RL_SlipRatio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_SlipRatio.ForeColor = System.Drawing.Color.White;
            this.label_RL_SlipRatio.Location = new System.Drawing.Point(414, 2);
            this.label_RL_SlipRatio.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_SlipRatio.Name = "label_RL_SlipRatio";
            this.label_RL_SlipRatio.Size = new System.Drawing.Size(206, 22);
            this.label_RL_SlipRatio.TabIndex = 97;
            this.label_RL_SlipRatio.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label152
            // 
            this.label152.BackColor = System.Drawing.Color.Black;
            this.label152.ForeColor = System.Drawing.Color.White;
            this.label152.Location = new System.Drawing.Point(624, 2);
            this.label152.MinimumSize = new System.Drawing.Size(0, 31);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(46, 31);
            this.label152.TabIndex = 33;
            this.label152.Text = "0-1";
            // 
            // panel3TelemetryRow8
            // 
            this.panel3TelemetryRow8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow8.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow8.Controls.Add(this.label122);
            this.panel3TelemetryRow8.Controls.Add(this.label_RL_LateralFriction);
            this.panel3TelemetryRow8.Controls.Add(this.label55);
            this.panel3TelemetryRow8.Controls.Add(this.label_RL_LongitudinalFriction);
            this.panel3TelemetryRow8.Controls.Add(this.label151);
            this.panel3TelemetryRow8.Location = new System.Drawing.Point(4, 213);
            this.panel3TelemetryRow8.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow8.Name = "panel3TelemetryRow8";
            this.panel3TelemetryRow8.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow8.TabIndex = 8;
            // 
            // label122
            // 
            this.label122.ForeColor = System.Drawing.Color.White;
            this.label122.Location = new System.Drawing.Point(4, 2);
            this.label122.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label122.MinimumSize = new System.Drawing.Size(0, 31);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(158, 31);
            this.label122.TabIndex = 315;
            this.label122.Text = "Lat/Lon Friction";
            // 
            // label_RL_LateralFriction
            // 
            this.label_RL_LateralFriction.BackColor = System.Drawing.Color.Black;
            this.label_RL_LateralFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_LateralFriction.ForeColor = System.Drawing.Color.White;
            this.label_RL_LateralFriction.Location = new System.Drawing.Point(165, 2);
            this.label_RL_LateralFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_LateralFriction.Name = "label_RL_LateralFriction";
            this.label_RL_LateralFriction.Size = new System.Drawing.Size(220, 22);
            this.label_RL_LateralFriction.TabIndex = 100;
            this.label_RL_LateralFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.Black;
            this.label55.ForeColor = System.Drawing.Color.White;
            this.label55.Location = new System.Drawing.Point(389, 2);
            this.label55.MinimumSize = new System.Drawing.Size(0, 31);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(27, 31);
            this.label55.TabIndex = 45;
            this.label55.Text = " /";
            // 
            // label_RL_LongitudinalFriction
            // 
            this.label_RL_LongitudinalFriction.BackColor = System.Drawing.Color.Black;
            this.label_RL_LongitudinalFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_LongitudinalFriction.ForeColor = System.Drawing.Color.White;
            this.label_RL_LongitudinalFriction.Location = new System.Drawing.Point(420, 2);
            this.label_RL_LongitudinalFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_LongitudinalFriction.Name = "label_RL_LongitudinalFriction";
            this.label_RL_LongitudinalFriction.Size = new System.Drawing.Size(220, 22);
            this.label_RL_LongitudinalFriction.TabIndex = 101;
            this.label_RL_LongitudinalFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label151
            // 
            this.label151.BackColor = System.Drawing.Color.Black;
            this.label151.ForeColor = System.Drawing.Color.White;
            this.label151.Location = new System.Drawing.Point(644, 2);
            this.label151.MinimumSize = new System.Drawing.Size(0, 31);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(27, 31);
            this.label151.TabIndex = 34;
            this.label151.Text = "μ";
            // 
            // panel3TelemetryRow9
            // 
            this.panel3TelemetryRow9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow9.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow9.Controls.Add(this.label121);
            this.panel3TelemetryRow9.Controls.Add(this.label_RL_LateralSlipSpeed);
            this.panel3TelemetryRow9.Controls.Add(this.label54);
            this.panel3TelemetryRow9.Controls.Add(this.label_RL_LongitudinalSlipSpeed);
            this.panel3TelemetryRow9.Controls.Add(this.label150);
            this.panel3TelemetryRow9.Location = new System.Drawing.Point(4, 239);
            this.panel3TelemetryRow9.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow9.Name = "panel3TelemetryRow9";
            this.panel3TelemetryRow9.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow9.TabIndex = 9;
            // 
            // label121
            // 
            this.label121.ForeColor = System.Drawing.Color.White;
            this.label121.Location = new System.Drawing.Point(4, 2);
            this.label121.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label121.MinimumSize = new System.Drawing.Size(0, 31);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(158, 31);
            this.label121.TabIndex = 316;
            this.label121.Text = "Lat/Lon Slip Speed";
            // 
            // label_RL_LateralSlipSpeed
            // 
            this.label_RL_LateralSlipSpeed.BackColor = System.Drawing.Color.Black;
            this.label_RL_LateralSlipSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_LateralSlipSpeed.ForeColor = System.Drawing.Color.White;
            this.label_RL_LateralSlipSpeed.Location = new System.Drawing.Point(165, 2);
            this.label_RL_LateralSlipSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_LateralSlipSpeed.Name = "label_RL_LateralSlipSpeed";
            this.label_RL_LateralSlipSpeed.Size = new System.Drawing.Size(209, 22);
            this.label_RL_LateralSlipSpeed.TabIndex = 135;
            this.label_RL_LateralSlipSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.Black;
            this.label54.ForeColor = System.Drawing.Color.White;
            this.label54.Location = new System.Drawing.Point(378, 2);
            this.label54.MinimumSize = new System.Drawing.Size(0, 31);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(27, 31);
            this.label54.TabIndex = 46;
            this.label54.Text = " /";
            // 
            // label_RL_LongitudinalSlipSpeed
            // 
            this.label_RL_LongitudinalSlipSpeed.BackColor = System.Drawing.Color.Black;
            this.label_RL_LongitudinalSlipSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_LongitudinalSlipSpeed.ForeColor = System.Drawing.Color.White;
            this.label_RL_LongitudinalSlipSpeed.Location = new System.Drawing.Point(409, 2);
            this.label_RL_LongitudinalSlipSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_LongitudinalSlipSpeed.Name = "label_RL_LongitudinalSlipSpeed";
            this.label_RL_LongitudinalSlipSpeed.Size = new System.Drawing.Size(209, 22);
            this.label_RL_LongitudinalSlipSpeed.TabIndex = 136;
            this.label_RL_LongitudinalSlipSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label150
            // 
            this.label150.BackColor = System.Drawing.Color.Black;
            this.label150.ForeColor = System.Drawing.Color.White;
            this.label150.Location = new System.Drawing.Point(622, 2);
            this.label150.MinimumSize = new System.Drawing.Size(0, 31);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(49, 31);
            this.label150.TabIndex = 35;
            this.label150.Text = "m/s";
            // 
            // panel3TelemetryRow10
            // 
            this.panel3TelemetryRow10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow10.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow10.Controls.Add(this.label120);
            this.panel3TelemetryRow10.Controls.Add(this.label_RL_TreadTemperature);
            this.panel3TelemetryRow10.Controls.Add(this.label51);
            this.panel3TelemetryRow10.Controls.Add(this.label_RL_InnerTemperature);
            this.panel3TelemetryRow10.Controls.Add(this.label149);
            this.panel3TelemetryRow10.Location = new System.Drawing.Point(4, 265);
            this.panel3TelemetryRow10.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow10.Name = "panel3TelemetryRow10";
            this.panel3TelemetryRow10.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow10.TabIndex = 10;
            // 
            // label120
            // 
            this.label120.ForeColor = System.Drawing.Color.White;
            this.label120.Location = new System.Drawing.Point(4, 2);
            this.label120.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label120.MinimumSize = new System.Drawing.Size(0, 31);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(158, 31);
            this.label120.TabIndex = 317;
            this.label120.Text = "Tread/Inner Temps";
            // 
            // label_RL_TreadTemperature
            // 
            this.label_RL_TreadTemperature.BackColor = System.Drawing.Color.Black;
            this.label_RL_TreadTemperature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_TreadTemperature.ForeColor = System.Drawing.Color.White;
            this.label_RL_TreadTemperature.Location = new System.Drawing.Point(165, 2);
            this.label_RL_TreadTemperature.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_TreadTemperature.Name = "label_RL_TreadTemperature";
            this.label_RL_TreadTemperature.Size = new System.Drawing.Size(203, 22);
            this.label_RL_TreadTemperature.TabIndex = 85;
            this.label_RL_TreadTemperature.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.Black;
            this.label51.ForeColor = System.Drawing.Color.White;
            this.label51.Location = new System.Drawing.Point(372, 2);
            this.label51.MinimumSize = new System.Drawing.Size(0, 31);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(50, 31);
            this.label51.TabIndex = 47;
            this.label51.Text = "°C /";
            // 
            // label_RL_InnerTemperature
            // 
            this.label_RL_InnerTemperature.BackColor = System.Drawing.Color.Black;
            this.label_RL_InnerTemperature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_InnerTemperature.ForeColor = System.Drawing.Color.White;
            this.label_RL_InnerTemperature.Location = new System.Drawing.Point(426, 2);
            this.label_RL_InnerTemperature.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_InnerTemperature.Name = "label_RL_InnerTemperature";
            this.label_RL_InnerTemperature.Size = new System.Drawing.Size(203, 22);
            this.label_RL_InnerTemperature.TabIndex = 86;
            this.label_RL_InnerTemperature.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label149
            // 
            this.label149.BackColor = System.Drawing.Color.Black;
            this.label149.ForeColor = System.Drawing.Color.White;
            this.label149.Location = new System.Drawing.Point(633, 2);
            this.label149.MinimumSize = new System.Drawing.Size(0, 31);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(38, 31);
            this.label149.TabIndex = 36;
            this.label149.Text = "°C";
            // 
            // panel3TelemetryRow11
            // 
            this.panel3TelemetryRow11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow11.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow11.Controls.Add(this.label119);
            this.panel3TelemetryRow11.Controls.Add(this.label_RL_TotalFriction);
            this.panel3TelemetryRow11.Controls.Add(this.label50);
            this.panel3TelemetryRow11.Controls.Add(this.label_RL_TotalFrictionAngle);
            this.panel3TelemetryRow11.Controls.Add(this.label148);
            this.panel3TelemetryRow11.Location = new System.Drawing.Point(4, 291);
            this.panel3TelemetryRow11.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow11.Name = "panel3TelemetryRow11";
            this.panel3TelemetryRow11.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow11.TabIndex = 11;
            // 
            // label119
            // 
            this.label119.ForeColor = System.Drawing.Color.White;
            this.label119.Location = new System.Drawing.Point(4, 2);
            this.label119.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label119.MinimumSize = new System.Drawing.Size(0, 31);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(158, 31);
            this.label119.TabIndex = 318;
            this.label119.Text = "Total Friction/Angle";
            // 
            // label_RL_TotalFriction
            // 
            this.label_RL_TotalFriction.BackColor = System.Drawing.Color.Black;
            this.label_RL_TotalFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_TotalFriction.ForeColor = System.Drawing.Color.White;
            this.label_RL_TotalFriction.Location = new System.Drawing.Point(165, 2);
            this.label_RL_TotalFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_TotalFriction.Name = "label_RL_TotalFriction";
            this.label_RL_TotalFriction.Size = new System.Drawing.Size(216, 22);
            this.label_RL_TotalFriction.TabIndex = 145;
            this.label_RL_TotalFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.Black;
            this.label50.ForeColor = System.Drawing.Color.White;
            this.label50.Location = new System.Drawing.Point(385, 2);
            this.label50.MinimumSize = new System.Drawing.Size(0, 31);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(39, 31);
            this.label50.TabIndex = 48;
            this.label50.Text = "μ /";
            // 
            // label_RL_TotalFrictionAngle
            // 
            this.label_RL_TotalFrictionAngle.BackColor = System.Drawing.Color.Black;
            this.label_RL_TotalFrictionAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_TotalFrictionAngle.ForeColor = System.Drawing.Color.White;
            this.label_RL_TotalFrictionAngle.Location = new System.Drawing.Point(428, 2);
            this.label_RL_TotalFrictionAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_TotalFrictionAngle.Name = "label_RL_TotalFrictionAngle";
            this.label_RL_TotalFrictionAngle.Size = new System.Drawing.Size(216, 22);
            this.label_RL_TotalFrictionAngle.TabIndex = 146;
            this.label_RL_TotalFrictionAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label148
            // 
            this.label148.BackColor = System.Drawing.Color.Black;
            this.label148.ForeColor = System.Drawing.Color.White;
            this.label148.Location = new System.Drawing.Point(648, 2);
            this.label148.MinimumSize = new System.Drawing.Size(0, 31);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(23, 31);
            this.label148.TabIndex = 37;
            this.label148.Text = "°";
            // 
            // panel3TelemetryRow12
            // 
            this.panel3TelemetryRow12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow12.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow12.Controls.Add(this.label118);
            this.panel3TelemetryRow12.Controls.Add(this.label_RL_SuspensionLength);
            this.panel3TelemetryRow12.Controls.Add(this.label49);
            this.panel3TelemetryRow12.Controls.Add(this.label_RL_SuspensionVelocity);
            this.panel3TelemetryRow12.Controls.Add(this.label147);
            this.panel3TelemetryRow12.Location = new System.Drawing.Point(4, 317);
            this.panel3TelemetryRow12.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow12.Name = "panel3TelemetryRow12";
            this.panel3TelemetryRow12.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow12.TabIndex = 12;
            // 
            // label118
            // 
            this.label118.ForeColor = System.Drawing.Color.White;
            this.label118.Location = new System.Drawing.Point(4, 2);
            this.label118.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label118.MinimumSize = new System.Drawing.Size(0, 31);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(158, 31);
            this.label118.TabIndex = 319;
            this.label118.Text = "Susp Length/Velocity";
            // 
            // label_RL_SuspensionLength
            // 
            this.label_RL_SuspensionLength.BackColor = System.Drawing.Color.Black;
            this.label_RL_SuspensionLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_SuspensionLength.ForeColor = System.Drawing.Color.White;
            this.label_RL_SuspensionLength.Location = new System.Drawing.Point(165, 2);
            this.label_RL_SuspensionLength.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_SuspensionLength.Name = "label_RL_SuspensionLength";
            this.label_RL_SuspensionLength.Size = new System.Drawing.Size(200, 22);
            this.label_RL_SuspensionLength.TabIndex = 234;
            this.label_RL_SuspensionLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Black;
            this.label49.ForeColor = System.Drawing.Color.White;
            this.label49.Location = new System.Drawing.Point(369, 2);
            this.label49.MinimumSize = new System.Drawing.Size(0, 31);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(44, 31);
            this.label49.TabIndex = 49;
            this.label49.Text = "m /";
            // 
            // label_RL_SuspensionVelocity
            // 
            this.label_RL_SuspensionVelocity.BackColor = System.Drawing.Color.Black;
            this.label_RL_SuspensionVelocity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_SuspensionVelocity.ForeColor = System.Drawing.Color.White;
            this.label_RL_SuspensionVelocity.Location = new System.Drawing.Point(417, 2);
            this.label_RL_SuspensionVelocity.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_SuspensionVelocity.Name = "label_RL_SuspensionVelocity";
            this.label_RL_SuspensionVelocity.Size = new System.Drawing.Size(200, 22);
            this.label_RL_SuspensionVelocity.TabIndex = 235;
            this.label_RL_SuspensionVelocity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label147
            // 
            this.label147.BackColor = System.Drawing.Color.Black;
            this.label147.ForeColor = System.Drawing.Color.White;
            this.label147.Location = new System.Drawing.Point(621, 2);
            this.label147.MinimumSize = new System.Drawing.Size(0, 31);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(49, 31);
            this.label147.TabIndex = 38;
            this.label147.Text = "m/s";
            // 
            // panel3TelemetryRow13
            // 
            this.panel3TelemetryRow13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow13.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow13.Controls.Add(this.label125);
            this.panel3TelemetryRow13.Controls.Add(this.label_RL_TireSteerAngle);
            this.panel3TelemetryRow13.Controls.Add(this.label48);
            this.panel3TelemetryRow13.Controls.Add(this.label_RL_CamberAngle);
            this.panel3TelemetryRow13.Controls.Add(this.label146);
            this.panel3TelemetryRow13.Location = new System.Drawing.Point(4, 343);
            this.panel3TelemetryRow13.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow13.Name = "panel3TelemetryRow13";
            this.panel3TelemetryRow13.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow13.TabIndex = 13;
            // 
            // label125
            // 
            this.label125.ForeColor = System.Drawing.Color.White;
            this.label125.Location = new System.Drawing.Point(4, 2);
            this.label125.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label125.MinimumSize = new System.Drawing.Size(0, 31);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(158, 31);
            this.label125.TabIndex = 312;
            this.label125.Text = "Steer/Camber Angle";
            // 
            // label_RL_TireSteerAngle
            // 
            this.label_RL_TireSteerAngle.BackColor = System.Drawing.Color.Black;
            this.label_RL_TireSteerAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_TireSteerAngle.ForeColor = System.Drawing.Color.White;
            this.label_RL_TireSteerAngle.Location = new System.Drawing.Point(165, 2);
            this.label_RL_TireSteerAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_TireSteerAngle.Name = "label_RL_TireSteerAngle";
            this.label_RL_TireSteerAngle.Size = new System.Drawing.Size(220, 22);
            this.label_RL_TireSteerAngle.TabIndex = 133;
            this.label_RL_TireSteerAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.Color.Black;
            this.label48.ForeColor = System.Drawing.Color.White;
            this.label48.Location = new System.Drawing.Point(389, 2);
            this.label48.MinimumSize = new System.Drawing.Size(0, 31);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(27, 31);
            this.label48.TabIndex = 50;
            this.label48.Text = " /";
            // 
            // label_RL_CamberAngle
            // 
            this.label_RL_CamberAngle.BackColor = System.Drawing.Color.Black;
            this.label_RL_CamberAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_CamberAngle.ForeColor = System.Drawing.Color.White;
            this.label_RL_CamberAngle.Location = new System.Drawing.Point(420, 2);
            this.label_RL_CamberAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_CamberAngle.Name = "label_RL_CamberAngle";
            this.label_RL_CamberAngle.Size = new System.Drawing.Size(220, 22);
            this.label_RL_CamberAngle.TabIndex = 134;
            this.label_RL_CamberAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label146
            // 
            this.label146.BackColor = System.Drawing.Color.Black;
            this.label146.ForeColor = System.Drawing.Color.White;
            this.label146.Location = new System.Drawing.Point(644, 2);
            this.label146.MinimumSize = new System.Drawing.Size(0, 31);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(23, 31);
            this.label146.TabIndex = 39;
            this.label146.Text = "°";
            // 
            // panel3TelemetryRow14
            // 
            this.panel3TelemetryRow14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow14.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow14.Controls.Add(this.label196);
            this.panel3TelemetryRow14.Controls.Add(this.label_RL_Mx);
            this.panel3TelemetryRow14.Controls.Add(this.label195);
            this.panel3TelemetryRow14.Controls.Add(this.label_RL_Mz);
            this.panel3TelemetryRow14.Controls.Add(this.label194);
            this.panel3TelemetryRow14.Controls.Add(this.label_RL_My);
            this.panel3TelemetryRow14.Location = new System.Drawing.Point(4, 369);
            this.panel3TelemetryRow14.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow14.Name = "panel3TelemetryRow14";
            this.panel3TelemetryRow14.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow14.TabIndex = 14;
            // 
            // label196
            // 
            this.label196.ForeColor = System.Drawing.Color.White;
            this.label196.Location = new System.Drawing.Point(4, 2);
            this.label196.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label196.MinimumSize = new System.Drawing.Size(0, 31);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(158, 31);
            this.label196.TabIndex = 323;
            this.label196.Text = "Mx/Mz/My";
            // 
            // label_RL_Mx
            // 
            this.label_RL_Mx.BackColor = System.Drawing.Color.Black;
            this.label_RL_Mx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_Mx.ForeColor = System.Drawing.Color.White;
            this.label_RL_Mx.Location = new System.Drawing.Point(165, 2);
            this.label_RL_Mx.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_Mx.Name = "label_RL_Mx";
            this.label_RL_Mx.Size = new System.Drawing.Size(145, 22);
            this.label_RL_Mx.TabIndex = 320;
            this.label_RL_Mx.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label195
            // 
            this.label195.BackColor = System.Drawing.Color.Black;
            this.label195.ForeColor = System.Drawing.Color.White;
            this.label195.Location = new System.Drawing.Point(314, 2);
            this.label195.MinimumSize = new System.Drawing.Size(0, 31);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(27, 31);
            this.label195.TabIndex = 324;
            this.label195.Text = " /";
            // 
            // label_RL_Mz
            // 
            this.label_RL_Mz.BackColor = System.Drawing.Color.Black;
            this.label_RL_Mz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_Mz.ForeColor = System.Drawing.Color.White;
            this.label_RL_Mz.Location = new System.Drawing.Point(345, 2);
            this.label_RL_Mz.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_Mz.Name = "label_RL_Mz";
            this.label_RL_Mz.Size = new System.Drawing.Size(145, 22);
            this.label_RL_Mz.TabIndex = 321;
            this.label_RL_Mz.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label194
            // 
            this.label194.BackColor = System.Drawing.Color.Black;
            this.label194.ForeColor = System.Drawing.Color.White;
            this.label194.Location = new System.Drawing.Point(494, 2);
            this.label194.MinimumSize = new System.Drawing.Size(0, 31);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(27, 31);
            this.label194.TabIndex = 325;
            this.label194.Text = " /";
            // 
            // label_RL_My
            // 
            this.label_RL_My.BackColor = System.Drawing.Color.Black;
            this.label_RL_My.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_My.ForeColor = System.Drawing.Color.White;
            this.label_RL_My.Location = new System.Drawing.Point(525, 2);
            this.label_RL_My.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_My.Name = "label_RL_My";
            this.label_RL_My.Size = new System.Drawing.Size(145, 22);
            this.label_RL_My.TabIndex = 322;
            this.label_RL_My.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel3TelemetryRow15
            // 
            this.panel3TelemetryRow15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3TelemetryRow15.BackColor = System.Drawing.Color.Black;
            this.panel3TelemetryRow15.Controls.Add(this.label204);
            this.panel3TelemetryRow15.Controls.Add(this.label_RL_PneumaticTrail);
            this.panel3TelemetryRow15.Controls.Add(this.label199);
            this.panel3TelemetryRow15.Controls.Add(this.label_RL_RollingResistance);
            this.panel3TelemetryRow15.Location = new System.Drawing.Point(4, 395);
            this.panel3TelemetryRow15.Margin = new System.Windows.Forms.Padding(0);
            this.panel3TelemetryRow15.Name = "panel3TelemetryRow15";
            this.panel3TelemetryRow15.Size = new System.Drawing.Size(436, 24);
            this.panel3TelemetryRow15.TabIndex = 15;
            // 
            // label204
            // 
            this.label204.ForeColor = System.Drawing.Color.White;
            this.label204.Location = new System.Drawing.Point(4, 2);
            this.label204.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label204.MinimumSize = new System.Drawing.Size(0, 31);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(158, 31);
            this.label204.TabIndex = 334;
            this.label204.Text = "Pt/Rr";
            // 
            // label_RL_PneumaticTrail
            // 
            this.label_RL_PneumaticTrail.BackColor = System.Drawing.Color.Black;
            this.label_RL_PneumaticTrail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_PneumaticTrail.ForeColor = System.Drawing.Color.White;
            this.label_RL_PneumaticTrail.Location = new System.Drawing.Point(165, 2);
            this.label_RL_PneumaticTrail.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_PneumaticTrail.Name = "label_RL_PneumaticTrail";
            this.label_RL_PneumaticTrail.Size = new System.Drawing.Size(220, 22);
            this.label_RL_PneumaticTrail.TabIndex = 335;
            this.label_RL_PneumaticTrail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label199
            // 
            this.label199.BackColor = System.Drawing.Color.Black;
            this.label199.ForeColor = System.Drawing.Color.White;
            this.label199.Location = new System.Drawing.Point(389, 2);
            this.label199.MinimumSize = new System.Drawing.Size(0, 31);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(44, 31);
            this.label199.TabIndex = 336;
            this.label199.Text = "m /";
            // 
            // label_RL_RollingResistance
            // 
            this.label_RL_RollingResistance.BackColor = System.Drawing.Color.Black;
            this.label_RL_RollingResistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RL_RollingResistance.ForeColor = System.Drawing.Color.White;
            this.label_RL_RollingResistance.Location = new System.Drawing.Point(437, 2);
            this.label_RL_RollingResistance.Margin = new System.Windows.Forms.Padding(6);
            this.label_RL_RollingResistance.Name = "label_RL_RollingResistance";
            this.label_RL_RollingResistance.Size = new System.Drawing.Size(220, 22);
            this.label_RL_RollingResistance.TabIndex = 306;
            this.label_RL_RollingResistance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel4TelemetryCard
            // 
            this.panel4TelemetryCard.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryCard.Controls.Add(this.panel4);
            this.panel4TelemetryCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4TelemetryCard.ForeColor = System.Drawing.Color.White;
            this.panel4TelemetryCard.Location = new System.Drawing.Point(603, 451);
            this.panel4TelemetryCard.Name = "panel4TelemetryCard";
            this.panel4TelemetryCard.Padding = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.panel4TelemetryCard.Size = new System.Drawing.Size(594, 442);
            this.panel4TelemetryCard.TabIndex = 3;
            this.panel4TelemetryCard.TabStop = false;
            this.panel4TelemetryCard.Text = "REAR RIGHT DATA";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.panel4TelemetryRow0);
            this.panel4.Controls.Add(this.panel4TelemetryRow1);
            this.panel4.Controls.Add(this.panel4TelemetryRow2);
            this.panel4.Controls.Add(this.panel4TelemetryRow3);
            this.panel4.Controls.Add(this.panel4TelemetryRow4);
            this.panel4.Controls.Add(this.panel4TelemetryRow5);
            this.panel4.Controls.Add(this.panel4TelemetryRow6);
            this.panel4.Controls.Add(this.panel4TelemetryRow7);
            this.panel4.Controls.Add(this.panel4TelemetryRow8);
            this.panel4.Controls.Add(this.panel4TelemetryRow9);
            this.panel4.Controls.Add(this.panel4TelemetryRow10);
            this.panel4.Controls.Add(this.panel4TelemetryRow11);
            this.panel4.Controls.Add(this.panel4TelemetryRow12);
            this.panel4.Controls.Add(this.panel4TelemetryRow13);
            this.panel4.Controls.Add(this.panel4TelemetryRow14);
            this.panel4.Controls.Add(this.panel4TelemetryRow15);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 39);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(588, 400);
            this.panel4.TabIndex = 291;
            // 
            // panel4TelemetryRow0
            // 
            this.panel4TelemetryRow0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow0.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow0.Controls.Add(this.label144);
            this.panel4TelemetryRow0.Controls.Add(this.label_RR_TravelSpeed);
            this.panel4TelemetryRow0.Controls.Add(this.label173);
            this.panel4TelemetryRow0.Location = new System.Drawing.Point(4, 5);
            this.panel4TelemetryRow0.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow0.Name = "panel4TelemetryRow0";
            this.panel4TelemetryRow0.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow0.TabIndex = 0;
            // 
            // label144
            // 
            this.label144.ForeColor = System.Drawing.Color.White;
            this.label144.Location = new System.Drawing.Point(4, 2);
            this.label144.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(158, 22);
            this.label144.TabIndex = 320;
            this.label144.Text = "Tire Travel Speed\r\n";
            // 
            // label_RR_TravelSpeed
            // 
            this.label_RR_TravelSpeed.BackColor = System.Drawing.Color.Black;
            this.label_RR_TravelSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_TravelSpeed.ForeColor = System.Drawing.Color.White;
            this.label_RR_TravelSpeed.Location = new System.Drawing.Point(165, 2);
            this.label_RR_TravelSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_TravelSpeed.Name = "label_RR_TravelSpeed";
            this.label_RR_TravelSpeed.Size = new System.Drawing.Size(220, 22);
            this.label_RR_TravelSpeed.TabIndex = 118;
            this.label_RR_TravelSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label173
            // 
            this.label173.BackColor = System.Drawing.Color.Black;
            this.label173.ForeColor = System.Drawing.Color.White;
            this.label173.Location = new System.Drawing.Point(389, 2);
            this.label173.MinimumSize = new System.Drawing.Size(0, 31);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(49, 31);
            this.label173.TabIndex = 320;
            this.label173.Text = "m/s";
            // 
            // panel4TelemetryRow1
            // 
            this.panel4TelemetryRow1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow1.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow1.Controls.Add(this.label145);
            this.panel4TelemetryRow1.Controls.Add(this.label_RR_AngularVelocity);
            this.panel4TelemetryRow1.Controls.Add(this.label172);
            this.panel4TelemetryRow1.Location = new System.Drawing.Point(4, 31);
            this.panel4TelemetryRow1.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow1.Name = "panel4TelemetryRow1";
            this.panel4TelemetryRow1.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow1.TabIndex = 1;
            // 
            // label145
            // 
            this.label145.ForeColor = System.Drawing.Color.White;
            this.label145.Location = new System.Drawing.Point(4, 2);
            this.label145.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(158, 22);
            this.label145.TabIndex = 321;
            this.label145.Text = "Angular Velocity";
            // 
            // label_RR_AngularVelocity
            // 
            this.label_RR_AngularVelocity.BackColor = System.Drawing.Color.Black;
            this.label_RR_AngularVelocity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_AngularVelocity.ForeColor = System.Drawing.Color.White;
            this.label_RR_AngularVelocity.Location = new System.Drawing.Point(165, 2);
            this.label_RR_AngularVelocity.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_AngularVelocity.Name = "label_RR_AngularVelocity";
            this.label_RR_AngularVelocity.Size = new System.Drawing.Size(220, 22);
            this.label_RR_AngularVelocity.TabIndex = 103;
            this.label_RR_AngularVelocity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label172
            // 
            this.label172.BackColor = System.Drawing.Color.Black;
            this.label172.ForeColor = System.Drawing.Color.White;
            this.label172.Location = new System.Drawing.Point(389, 2);
            this.label172.MinimumSize = new System.Drawing.Size(0, 31);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(60, 31);
            this.label172.TabIndex = 321;
            this.label172.Text = "km/h";
            // 
            // panel4TelemetryRow2
            // 
            this.panel4TelemetryRow2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow2.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow2.Controls.Add(this.label143);
            this.panel4TelemetryRow2.Controls.Add(this.label_RR_VerticalLoad);
            this.panel4TelemetryRow2.Controls.Add(this.label62);
            this.panel4TelemetryRow2.Controls.Add(this.label_RR_Deflection);
            this.panel4TelemetryRow2.Controls.Add(this.label171);
            this.panel4TelemetryRow2.Location = new System.Drawing.Point(4, 57);
            this.panel4TelemetryRow2.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow2.Name = "panel4TelemetryRow2";
            this.panel4TelemetryRow2.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow2.TabIndex = 2;
            // 
            // label143
            // 
            this.label143.ForeColor = System.Drawing.Color.White;
            this.label143.Location = new System.Drawing.Point(4, 2);
            this.label143.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(158, 22);
            this.label143.TabIndex = 322;
            this.label143.Text = "Vertical Load/Deflection";
            // 
            // label_RR_VerticalLoad
            // 
            this.label_RR_VerticalLoad.BackColor = System.Drawing.Color.Black;
            this.label_RR_VerticalLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_VerticalLoad.ForeColor = System.Drawing.Color.White;
            this.label_RR_VerticalLoad.Location = new System.Drawing.Point(165, 2);
            this.label_RR_VerticalLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_VerticalLoad.Name = "label_RR_VerticalLoad";
            this.label_RR_VerticalLoad.Size = new System.Drawing.Size(210, 22);
            this.label_RR_VerticalLoad.TabIndex = 111;
            this.label_RR_VerticalLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.Black;
            this.label62.ForeColor = System.Drawing.Color.White;
            this.label62.Location = new System.Drawing.Point(379, 2);
            this.label62.MinimumSize = new System.Drawing.Size(0, 31);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(42, 31);
            this.label62.TabIndex = 51;
            this.label62.Text = "N /";
            // 
            // label_RR_Deflection
            // 
            this.label_RR_Deflection.BackColor = System.Drawing.Color.Black;
            this.label_RR_Deflection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_Deflection.ForeColor = System.Drawing.Color.White;
            this.label_RR_Deflection.Location = new System.Drawing.Point(425, 2);
            this.label_RR_Deflection.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_Deflection.Name = "label_RR_Deflection";
            this.label_RR_Deflection.Size = new System.Drawing.Size(210, 22);
            this.label_RR_Deflection.TabIndex = 106;
            this.label_RR_Deflection.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label171
            // 
            this.label171.BackColor = System.Drawing.Color.Black;
            this.label171.ForeColor = System.Drawing.Color.White;
            this.label171.Location = new System.Drawing.Point(639, 2);
            this.label171.MinimumSize = new System.Drawing.Size(0, 31);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(32, 31);
            this.label171.TabIndex = 322;
            this.label171.Text = "m";
            // 
            // panel4TelemetryRow3
            // 
            this.panel4TelemetryRow3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow3.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow3.Controls.Add(this.label142);
            this.panel4TelemetryRow3.Controls.Add(this.label_RR_LoadedRadius);
            this.panel4TelemetryRow3.Controls.Add(this.label64);
            this.panel4TelemetryRow3.Controls.Add(this.label_RR_EffectiveRadius);
            this.panel4TelemetryRow3.Controls.Add(this.label170);
            this.panel4TelemetryRow3.Location = new System.Drawing.Point(4, 83);
            this.panel4TelemetryRow3.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow3.Name = "panel4TelemetryRow3";
            this.panel4TelemetryRow3.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow3.TabIndex = 3;
            // 
            // label142
            // 
            this.label142.ForeColor = System.Drawing.Color.White;
            this.label142.Location = new System.Drawing.Point(4, 2);
            this.label142.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(158, 22);
            this.label142.TabIndex = 323;
            this.label142.Text = "Loaded/Effective Radius";
            // 
            // label_RR_LoadedRadius
            // 
            this.label_RR_LoadedRadius.BackColor = System.Drawing.Color.Black;
            this.label_RR_LoadedRadius.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_LoadedRadius.ForeColor = System.Drawing.Color.White;
            this.label_RR_LoadedRadius.Location = new System.Drawing.Point(165, 2);
            this.label_RR_LoadedRadius.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_LoadedRadius.Name = "label_RR_LoadedRadius";
            this.label_RR_LoadedRadius.Size = new System.Drawing.Size(209, 22);
            this.label_RR_LoadedRadius.TabIndex = 107;
            this.label_RR_LoadedRadius.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.Color.Black;
            this.label64.ForeColor = System.Drawing.Color.White;
            this.label64.Location = new System.Drawing.Point(378, 2);
            this.label64.MinimumSize = new System.Drawing.Size(0, 31);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(44, 31);
            this.label64.TabIndex = 52;
            this.label64.Text = "m /";
            // 
            // label_RR_EffectiveRadius
            // 
            this.label_RR_EffectiveRadius.BackColor = System.Drawing.Color.Black;
            this.label_RR_EffectiveRadius.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_EffectiveRadius.ForeColor = System.Drawing.Color.White;
            this.label_RR_EffectiveRadius.Location = new System.Drawing.Point(426, 2);
            this.label_RR_EffectiveRadius.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_EffectiveRadius.Name = "label_RR_EffectiveRadius";
            this.label_RR_EffectiveRadius.Size = new System.Drawing.Size(209, 22);
            this.label_RR_EffectiveRadius.TabIndex = 108;
            this.label_RR_EffectiveRadius.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label170
            // 
            this.label170.BackColor = System.Drawing.Color.Black;
            this.label170.ForeColor = System.Drawing.Color.White;
            this.label170.Location = new System.Drawing.Point(639, 2);
            this.label170.MinimumSize = new System.Drawing.Size(0, 31);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(32, 31);
            this.label170.TabIndex = 323;
            this.label170.Text = "m";
            // 
            // panel4TelemetryRow4
            // 
            this.panel4TelemetryRow4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow4.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow4.Controls.Add(this.label141);
            this.panel4TelemetryRow4.Controls.Add(this.label_RR_ContactLength);
            this.panel4TelemetryRow4.Controls.Add(this.label169);
            this.panel4TelemetryRow4.Location = new System.Drawing.Point(4, 109);
            this.panel4TelemetryRow4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow4.Name = "panel4TelemetryRow4";
            this.panel4TelemetryRow4.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow4.TabIndex = 4;
            // 
            // label141
            // 
            this.label141.ForeColor = System.Drawing.Color.White;
            this.label141.Location = new System.Drawing.Point(4, 2);
            this.label141.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(158, 22);
            this.label141.TabIndex = 324;
            this.label141.Text = "Contact Length";
            // 
            // label_RR_ContactLength
            // 
            this.label_RR_ContactLength.BackColor = System.Drawing.Color.Black;
            this.label_RR_ContactLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_ContactLength.ForeColor = System.Drawing.Color.White;
            this.label_RR_ContactLength.Location = new System.Drawing.Point(165, 2);
            this.label_RR_ContactLength.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_ContactLength.Name = "label_RR_ContactLength";
            this.label_RR_ContactLength.Size = new System.Drawing.Size(220, 22);
            this.label_RR_ContactLength.TabIndex = 117;
            this.label_RR_ContactLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label169
            // 
            this.label169.BackColor = System.Drawing.Color.Black;
            this.label169.ForeColor = System.Drawing.Color.White;
            this.label169.Location = new System.Drawing.Point(389, 2);
            this.label169.MinimumSize = new System.Drawing.Size(0, 31);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(32, 31);
            this.label169.TabIndex = 324;
            this.label169.Text = "m";
            // 
            // panel4TelemetryRow5
            // 
            this.panel4TelemetryRow5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow5.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow5.Controls.Add(this.label140);
            this.panel4TelemetryRow5.Controls.Add(this.label_RR_CurrentContactBrakeTorque);
            this.panel4TelemetryRow5.Controls.Add(this.label73);
            this.panel4TelemetryRow5.Controls.Add(this.label_RR_MaxCurrentContactBrakeTorque);
            this.panel4TelemetryRow5.Controls.Add(this.label168);
            this.panel4TelemetryRow5.Location = new System.Drawing.Point(4, 135);
            this.panel4TelemetryRow5.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow5.Name = "panel4TelemetryRow5";
            this.panel4TelemetryRow5.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow5.TabIndex = 5;
            // 
            // label140
            // 
            this.label140.ForeColor = System.Drawing.Color.White;
            this.label140.Location = new System.Drawing.Point(4, 2);
            this.label140.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(158, 22);
            this.label140.TabIndex = 325;
            this.label140.Text = "Braking Torque";
            // 
            // label_RR_CurrentContactBrakeTorque
            // 
            this.label_RR_CurrentContactBrakeTorque.BackColor = System.Drawing.Color.Black;
            this.label_RR_CurrentContactBrakeTorque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_CurrentContactBrakeTorque.ForeColor = System.Drawing.Color.White;
            this.label_RR_CurrentContactBrakeTorque.Location = new System.Drawing.Point(165, 2);
            this.label_RR_CurrentContactBrakeTorque.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_CurrentContactBrakeTorque.Name = "label_RR_CurrentContactBrakeTorque";
            this.label_RR_CurrentContactBrakeTorque.Size = new System.Drawing.Size(210, 22);
            this.label_RR_CurrentContactBrakeTorque.TabIndex = 109;
            this.label_RR_CurrentContactBrakeTorque.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label73
            // 
            this.label73.BackColor = System.Drawing.Color.Black;
            this.label73.ForeColor = System.Drawing.Color.White;
            this.label73.Location = new System.Drawing.Point(379, 2);
            this.label73.MinimumSize = new System.Drawing.Size(0, 31);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(27, 31);
            this.label73.TabIndex = 53;
            this.label73.Text = " /";
            // 
            // label_RR_MaxCurrentContactBrakeTorque
            // 
            this.label_RR_MaxCurrentContactBrakeTorque.BackColor = System.Drawing.Color.Black;
            this.label_RR_MaxCurrentContactBrakeTorque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_MaxCurrentContactBrakeTorque.ForeColor = System.Drawing.Color.White;
            this.label_RR_MaxCurrentContactBrakeTorque.Location = new System.Drawing.Point(410, 2);
            this.label_RR_MaxCurrentContactBrakeTorque.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_MaxCurrentContactBrakeTorque.Name = "label_RR_MaxCurrentContactBrakeTorque";
            this.label_RR_MaxCurrentContactBrakeTorque.Size = new System.Drawing.Size(210, 22);
            this.label_RR_MaxCurrentContactBrakeTorque.TabIndex = 154;
            this.label_RR_MaxCurrentContactBrakeTorque.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label168
            // 
            this.label168.BackColor = System.Drawing.Color.Black;
            this.label168.ForeColor = System.Drawing.Color.White;
            this.label168.Location = new System.Drawing.Point(624, 2);
            this.label168.MinimumSize = new System.Drawing.Size(0, 31);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(47, 31);
            this.label168.TabIndex = 325;
            this.label168.Text = "Nm";
            // 
            // panel4TelemetryRow6
            // 
            this.panel4TelemetryRow6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow6.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow6.Controls.Add(this.label138);
            this.panel4TelemetryRow6.Controls.Add(this.label_RR_LateralLoad);
            this.panel4TelemetryRow6.Controls.Add(this.label100);
            this.panel4TelemetryRow6.Controls.Add(this.label_RR_LongitudinalLoad);
            this.panel4TelemetryRow6.Controls.Add(this.label167);
            this.panel4TelemetryRow6.Location = new System.Drawing.Point(4, 161);
            this.panel4TelemetryRow6.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow6.Name = "panel4TelemetryRow6";
            this.panel4TelemetryRow6.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow6.TabIndex = 6;
            // 
            // label138
            // 
            this.label138.ForeColor = System.Drawing.Color.White;
            this.label138.Location = new System.Drawing.Point(4, 2);
            this.label138.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(158, 22);
            this.label138.TabIndex = 327;
            this.label138.Text = "Lat/Lon Load";
            // 
            // label_RR_LateralLoad
            // 
            this.label_RR_LateralLoad.BackColor = System.Drawing.Color.Black;
            this.label_RR_LateralLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_LateralLoad.ForeColor = System.Drawing.Color.White;
            this.label_RR_LateralLoad.Location = new System.Drawing.Point(165, 2);
            this.label_RR_LateralLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_LateralLoad.Name = "label_RR_LateralLoad";
            this.label_RR_LateralLoad.Size = new System.Drawing.Size(218, 22);
            this.label_RR_LateralLoad.TabIndex = 112;
            this.label_RR_LateralLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label100
            // 
            this.label100.BackColor = System.Drawing.Color.Black;
            this.label100.ForeColor = System.Drawing.Color.White;
            this.label100.Location = new System.Drawing.Point(387, 2);
            this.label100.MinimumSize = new System.Drawing.Size(0, 31);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(27, 31);
            this.label100.TabIndex = 54;
            this.label100.Text = " /";
            // 
            // label_RR_LongitudinalLoad
            // 
            this.label_RR_LongitudinalLoad.BackColor = System.Drawing.Color.Black;
            this.label_RR_LongitudinalLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_LongitudinalLoad.ForeColor = System.Drawing.Color.White;
            this.label_RR_LongitudinalLoad.Location = new System.Drawing.Point(418, 2);
            this.label_RR_LongitudinalLoad.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_LongitudinalLoad.Name = "label_RR_LongitudinalLoad";
            this.label_RR_LongitudinalLoad.Size = new System.Drawing.Size(218, 22);
            this.label_RR_LongitudinalLoad.TabIndex = 113;
            this.label_RR_LongitudinalLoad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label167
            // 
            this.label167.BackColor = System.Drawing.Color.Black;
            this.label167.ForeColor = System.Drawing.Color.White;
            this.label167.Location = new System.Drawing.Point(640, 2);
            this.label167.MinimumSize = new System.Drawing.Size(0, 31);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(30, 31);
            this.label167.TabIndex = 326;
            this.label167.Text = "N";
            // 
            // panel4TelemetryRow7
            // 
            this.panel4TelemetryRow7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow7.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow7.Controls.Add(this.label137);
            this.panel4TelemetryRow7.Controls.Add(this.label_RR_SlipAngleDeg);
            this.panel4TelemetryRow7.Controls.Add(this.label102);
            this.panel4TelemetryRow7.Controls.Add(this.label_RR_SlipRatio);
            this.panel4TelemetryRow7.Controls.Add(this.label166);
            this.panel4TelemetryRow7.Location = new System.Drawing.Point(4, 187);
            this.panel4TelemetryRow7.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow7.Name = "panel4TelemetryRow7";
            this.panel4TelemetryRow7.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow7.TabIndex = 7;
            // 
            // label137
            // 
            this.label137.ForeColor = System.Drawing.Color.White;
            this.label137.Location = new System.Drawing.Point(4, 2);
            this.label137.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(158, 22);
            this.label137.TabIndex = 328;
            this.label137.Text = "Slip Angle/Ratio";
            // 
            // label_RR_SlipAngleDeg
            // 
            this.label_RR_SlipAngleDeg.BackColor = System.Drawing.Color.Black;
            this.label_RR_SlipAngleDeg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_SlipAngleDeg.ForeColor = System.Drawing.Color.White;
            this.label_RR_SlipAngleDeg.Location = new System.Drawing.Point(165, 2);
            this.label_RR_SlipAngleDeg.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_SlipAngleDeg.Name = "label_RR_SlipAngleDeg";
            this.label_RR_SlipAngleDeg.Size = new System.Drawing.Size(206, 22);
            this.label_RR_SlipAngleDeg.TabIndex = 115;
            this.label_RR_SlipAngleDeg.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label102
            // 
            this.label102.BackColor = System.Drawing.Color.Black;
            this.label102.ForeColor = System.Drawing.Color.White;
            this.label102.Location = new System.Drawing.Point(375, 2);
            this.label102.MinimumSize = new System.Drawing.Size(0, 31);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(35, 31);
            this.label102.TabIndex = 55;
            this.label102.Text = "° /";
            // 
            // label_RR_SlipRatio
            // 
            this.label_RR_SlipRatio.BackColor = System.Drawing.Color.Black;
            this.label_RR_SlipRatio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_SlipRatio.ForeColor = System.Drawing.Color.White;
            this.label_RR_SlipRatio.Location = new System.Drawing.Point(414, 2);
            this.label_RR_SlipRatio.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_SlipRatio.Name = "label_RR_SlipRatio";
            this.label_RR_SlipRatio.Size = new System.Drawing.Size(206, 22);
            this.label_RR_SlipRatio.TabIndex = 116;
            this.label_RR_SlipRatio.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label166
            // 
            this.label166.BackColor = System.Drawing.Color.Black;
            this.label166.ForeColor = System.Drawing.Color.White;
            this.label166.Location = new System.Drawing.Point(624, 2);
            this.label166.MinimumSize = new System.Drawing.Size(0, 31);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(46, 31);
            this.label166.TabIndex = 327;
            this.label166.Text = "0-1";
            // 
            // panel4TelemetryRow8
            // 
            this.panel4TelemetryRow8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow8.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow8.Controls.Add(this.label136);
            this.panel4TelemetryRow8.Controls.Add(this.label_RR_LateralFriction);
            this.panel4TelemetryRow8.Controls.Add(this.label103);
            this.panel4TelemetryRow8.Controls.Add(this.label_RR_LongitudinalFriction);
            this.panel4TelemetryRow8.Controls.Add(this.label165);
            this.panel4TelemetryRow8.Location = new System.Drawing.Point(4, 213);
            this.panel4TelemetryRow8.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow8.Name = "panel4TelemetryRow8";
            this.panel4TelemetryRow8.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow8.TabIndex = 8;
            // 
            // label136
            // 
            this.label136.ForeColor = System.Drawing.Color.White;
            this.label136.Location = new System.Drawing.Point(4, 2);
            this.label136.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(158, 22);
            this.label136.TabIndex = 329;
            this.label136.Text = "Lat/Lon Friction";
            // 
            // label_RR_LateralFriction
            // 
            this.label_RR_LateralFriction.BackColor = System.Drawing.Color.Black;
            this.label_RR_LateralFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_LateralFriction.ForeColor = System.Drawing.Color.White;
            this.label_RR_LateralFriction.Location = new System.Drawing.Point(165, 2);
            this.label_RR_LateralFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_LateralFriction.Name = "label_RR_LateralFriction";
            this.label_RR_LateralFriction.Size = new System.Drawing.Size(220, 22);
            this.label_RR_LateralFriction.TabIndex = 119;
            this.label_RR_LateralFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label103
            // 
            this.label103.BackColor = System.Drawing.Color.Black;
            this.label103.ForeColor = System.Drawing.Color.White;
            this.label103.Location = new System.Drawing.Point(389, 2);
            this.label103.MinimumSize = new System.Drawing.Size(0, 31);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(27, 31);
            this.label103.TabIndex = 56;
            this.label103.Text = " /";
            // 
            // label_RR_LongitudinalFriction
            // 
            this.label_RR_LongitudinalFriction.BackColor = System.Drawing.Color.Black;
            this.label_RR_LongitudinalFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_LongitudinalFriction.ForeColor = System.Drawing.Color.White;
            this.label_RR_LongitudinalFriction.Location = new System.Drawing.Point(420, 2);
            this.label_RR_LongitudinalFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_LongitudinalFriction.Name = "label_RR_LongitudinalFriction";
            this.label_RR_LongitudinalFriction.Size = new System.Drawing.Size(220, 22);
            this.label_RR_LongitudinalFriction.TabIndex = 120;
            this.label_RR_LongitudinalFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label165
            // 
            this.label165.BackColor = System.Drawing.Color.Black;
            this.label165.ForeColor = System.Drawing.Color.White;
            this.label165.Location = new System.Drawing.Point(644, 2);
            this.label165.MinimumSize = new System.Drawing.Size(0, 31);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(27, 31);
            this.label165.TabIndex = 328;
            this.label165.Text = "μ";
            // 
            // panel4TelemetryRow9
            // 
            this.panel4TelemetryRow9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow9.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow9.Controls.Add(this.label135);
            this.panel4TelemetryRow9.Controls.Add(this.label_RR_LateralSlipSpeed);
            this.panel4TelemetryRow9.Controls.Add(this.label101);
            this.panel4TelemetryRow9.Controls.Add(this.label_RR_LongitudinalSlipSpeed);
            this.panel4TelemetryRow9.Controls.Add(this.label164);
            this.panel4TelemetryRow9.Location = new System.Drawing.Point(4, 239);
            this.panel4TelemetryRow9.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow9.Name = "panel4TelemetryRow9";
            this.panel4TelemetryRow9.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow9.TabIndex = 9;
            // 
            // label135
            // 
            this.label135.ForeColor = System.Drawing.Color.White;
            this.label135.Location = new System.Drawing.Point(4, 2);
            this.label135.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(158, 22);
            this.label135.TabIndex = 330;
            this.label135.Text = "Lat/Lon Slip Speed";
            // 
            // label_RR_LateralSlipSpeed
            // 
            this.label_RR_LateralSlipSpeed.BackColor = System.Drawing.Color.Black;
            this.label_RR_LateralSlipSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_LateralSlipSpeed.ForeColor = System.Drawing.Color.White;
            this.label_RR_LateralSlipSpeed.Location = new System.Drawing.Point(165, 2);
            this.label_RR_LateralSlipSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_LateralSlipSpeed.Name = "label_RR_LateralSlipSpeed";
            this.label_RR_LateralSlipSpeed.Size = new System.Drawing.Size(209, 22);
            this.label_RR_LateralSlipSpeed.TabIndex = 139;
            this.label_RR_LateralSlipSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label101
            // 
            this.label101.BackColor = System.Drawing.Color.Black;
            this.label101.ForeColor = System.Drawing.Color.White;
            this.label101.Location = new System.Drawing.Point(378, 2);
            this.label101.MinimumSize = new System.Drawing.Size(0, 31);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(27, 31);
            this.label101.TabIndex = 57;
            this.label101.Text = " /";
            // 
            // label_RR_LongitudinalSlipSpeed
            // 
            this.label_RR_LongitudinalSlipSpeed.BackColor = System.Drawing.Color.Black;
            this.label_RR_LongitudinalSlipSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_LongitudinalSlipSpeed.ForeColor = System.Drawing.Color.White;
            this.label_RR_LongitudinalSlipSpeed.Location = new System.Drawing.Point(409, 2);
            this.label_RR_LongitudinalSlipSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_LongitudinalSlipSpeed.Name = "label_RR_LongitudinalSlipSpeed";
            this.label_RR_LongitudinalSlipSpeed.Size = new System.Drawing.Size(209, 22);
            this.label_RR_LongitudinalSlipSpeed.TabIndex = 140;
            this.label_RR_LongitudinalSlipSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label164
            // 
            this.label164.BackColor = System.Drawing.Color.Black;
            this.label164.ForeColor = System.Drawing.Color.White;
            this.label164.Location = new System.Drawing.Point(622, 2);
            this.label164.MinimumSize = new System.Drawing.Size(0, 31);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(49, 31);
            this.label164.TabIndex = 329;
            this.label164.Text = "m/s";
            // 
            // panel4TelemetryRow10
            // 
            this.panel4TelemetryRow10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow10.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow10.Controls.Add(this.label134);
            this.panel4TelemetryRow10.Controls.Add(this.label_RR_TreadTemperature);
            this.panel4TelemetryRow10.Controls.Add(this.label99);
            this.panel4TelemetryRow10.Controls.Add(this.label_RR_InnerTemperature);
            this.panel4TelemetryRow10.Controls.Add(this.label163);
            this.panel4TelemetryRow10.Location = new System.Drawing.Point(4, 265);
            this.panel4TelemetryRow10.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow10.Name = "panel4TelemetryRow10";
            this.panel4TelemetryRow10.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow10.TabIndex = 10;
            // 
            // label134
            // 
            this.label134.ForeColor = System.Drawing.Color.White;
            this.label134.Location = new System.Drawing.Point(4, 2);
            this.label134.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(158, 22);
            this.label134.TabIndex = 331;
            this.label134.Text = "Tread/Inner Temps";
            // 
            // label_RR_TreadTemperature
            // 
            this.label_RR_TreadTemperature.BackColor = System.Drawing.Color.Black;
            this.label_RR_TreadTemperature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_TreadTemperature.ForeColor = System.Drawing.Color.White;
            this.label_RR_TreadTemperature.Location = new System.Drawing.Point(165, 2);
            this.label_RR_TreadTemperature.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_TreadTemperature.Name = "label_RR_TreadTemperature";
            this.label_RR_TreadTemperature.Size = new System.Drawing.Size(203, 22);
            this.label_RR_TreadTemperature.TabIndex = 104;
            this.label_RR_TreadTemperature.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.Color.Black;
            this.label99.ForeColor = System.Drawing.Color.White;
            this.label99.Location = new System.Drawing.Point(372, 2);
            this.label99.MinimumSize = new System.Drawing.Size(0, 31);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(50, 31);
            this.label99.TabIndex = 58;
            this.label99.Text = "°C /";
            // 
            // label_RR_InnerTemperature
            // 
            this.label_RR_InnerTemperature.BackColor = System.Drawing.Color.Black;
            this.label_RR_InnerTemperature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_InnerTemperature.ForeColor = System.Drawing.Color.White;
            this.label_RR_InnerTemperature.Location = new System.Drawing.Point(426, 2);
            this.label_RR_InnerTemperature.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_InnerTemperature.Name = "label_RR_InnerTemperature";
            this.label_RR_InnerTemperature.Size = new System.Drawing.Size(203, 22);
            this.label_RR_InnerTemperature.TabIndex = 105;
            this.label_RR_InnerTemperature.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label163
            // 
            this.label163.BackColor = System.Drawing.Color.Black;
            this.label163.ForeColor = System.Drawing.Color.White;
            this.label163.Location = new System.Drawing.Point(633, 2);
            this.label163.MinimumSize = new System.Drawing.Size(0, 31);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(38, 31);
            this.label163.TabIndex = 330;
            this.label163.Text = "°C";
            // 
            // panel4TelemetryRow11
            // 
            this.panel4TelemetryRow11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow11.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow11.Controls.Add(this.label133);
            this.panel4TelemetryRow11.Controls.Add(this.label_RR_TotalFriction);
            this.panel4TelemetryRow11.Controls.Add(this.label72);
            this.panel4TelemetryRow11.Controls.Add(this.label_RR_TotalFrictionAngle);
            this.panel4TelemetryRow11.Controls.Add(this.label162);
            this.panel4TelemetryRow11.Location = new System.Drawing.Point(4, 291);
            this.panel4TelemetryRow11.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow11.Name = "panel4TelemetryRow11";
            this.panel4TelemetryRow11.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow11.TabIndex = 11;
            // 
            // label133
            // 
            this.label133.ForeColor = System.Drawing.Color.White;
            this.label133.Location = new System.Drawing.Point(4, 2);
            this.label133.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(158, 22);
            this.label133.TabIndex = 332;
            this.label133.Text = "Total Friction/Angle";
            // 
            // label_RR_TotalFriction
            // 
            this.label_RR_TotalFriction.BackColor = System.Drawing.Color.Black;
            this.label_RR_TotalFriction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_TotalFriction.ForeColor = System.Drawing.Color.White;
            this.label_RR_TotalFriction.Location = new System.Drawing.Point(165, 2);
            this.label_RR_TotalFriction.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_TotalFriction.Name = "label_RR_TotalFriction";
            this.label_RR_TotalFriction.Size = new System.Drawing.Size(216, 22);
            this.label_RR_TotalFriction.TabIndex = 147;
            this.label_RR_TotalFriction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.Color.Black;
            this.label72.ForeColor = System.Drawing.Color.White;
            this.label72.Location = new System.Drawing.Point(385, 2);
            this.label72.MinimumSize = new System.Drawing.Size(0, 31);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(39, 31);
            this.label72.TabIndex = 59;
            this.label72.Text = "μ /";
            // 
            // label_RR_TotalFrictionAngle
            // 
            this.label_RR_TotalFrictionAngle.BackColor = System.Drawing.Color.Black;
            this.label_RR_TotalFrictionAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_TotalFrictionAngle.ForeColor = System.Drawing.Color.White;
            this.label_RR_TotalFrictionAngle.Location = new System.Drawing.Point(428, 2);
            this.label_RR_TotalFrictionAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_TotalFrictionAngle.Name = "label_RR_TotalFrictionAngle";
            this.label_RR_TotalFrictionAngle.Size = new System.Drawing.Size(216, 22);
            this.label_RR_TotalFrictionAngle.TabIndex = 148;
            this.label_RR_TotalFrictionAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label162
            // 
            this.label162.BackColor = System.Drawing.Color.Black;
            this.label162.ForeColor = System.Drawing.Color.White;
            this.label162.Location = new System.Drawing.Point(648, 2);
            this.label162.MinimumSize = new System.Drawing.Size(0, 31);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(23, 31);
            this.label162.TabIndex = 331;
            this.label162.Text = "°";
            // 
            // panel4TelemetryRow12
            // 
            this.panel4TelemetryRow12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow12.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow12.Controls.Add(this.label132);
            this.panel4TelemetryRow12.Controls.Add(this.label_RR_SuspensionLength);
            this.panel4TelemetryRow12.Controls.Add(this.label63);
            this.panel4TelemetryRow12.Controls.Add(this.label_RR_SuspensionVelocity);
            this.panel4TelemetryRow12.Controls.Add(this.label161);
            this.panel4TelemetryRow12.Location = new System.Drawing.Point(4, 317);
            this.panel4TelemetryRow12.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow12.Name = "panel4TelemetryRow12";
            this.panel4TelemetryRow12.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow12.TabIndex = 12;
            // 
            // label132
            // 
            this.label132.ForeColor = System.Drawing.Color.White;
            this.label132.Location = new System.Drawing.Point(4, 2);
            this.label132.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(158, 22);
            this.label132.TabIndex = 333;
            this.label132.Text = "Susp Length/Velocity";
            // 
            // label_RR_SuspensionLength
            // 
            this.label_RR_SuspensionLength.BackColor = System.Drawing.Color.Black;
            this.label_RR_SuspensionLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_SuspensionLength.ForeColor = System.Drawing.Color.White;
            this.label_RR_SuspensionLength.Location = new System.Drawing.Point(165, 2);
            this.label_RR_SuspensionLength.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_SuspensionLength.Name = "label_RR_SuspensionLength";
            this.label_RR_SuspensionLength.Size = new System.Drawing.Size(200, 22);
            this.label_RR_SuspensionLength.TabIndex = 237;
            this.label_RR_SuspensionLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.Black;
            this.label63.ForeColor = System.Drawing.Color.White;
            this.label63.Location = new System.Drawing.Point(369, 2);
            this.label63.MinimumSize = new System.Drawing.Size(0, 31);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(44, 31);
            this.label63.TabIndex = 60;
            this.label63.Text = "m /";
            // 
            // label_RR_SuspensionVelocity
            // 
            this.label_RR_SuspensionVelocity.BackColor = System.Drawing.Color.Black;
            this.label_RR_SuspensionVelocity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_SuspensionVelocity.ForeColor = System.Drawing.Color.White;
            this.label_RR_SuspensionVelocity.Location = new System.Drawing.Point(417, 2);
            this.label_RR_SuspensionVelocity.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_SuspensionVelocity.Name = "label_RR_SuspensionVelocity";
            this.label_RR_SuspensionVelocity.Size = new System.Drawing.Size(200, 22);
            this.label_RR_SuspensionVelocity.TabIndex = 238;
            this.label_RR_SuspensionVelocity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label161
            // 
            this.label161.BackColor = System.Drawing.Color.Black;
            this.label161.ForeColor = System.Drawing.Color.White;
            this.label161.Location = new System.Drawing.Point(621, 2);
            this.label161.MinimumSize = new System.Drawing.Size(0, 31);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(49, 31);
            this.label161.TabIndex = 332;
            this.label161.Text = "m/s";
            // 
            // panel4TelemetryRow13
            // 
            this.panel4TelemetryRow13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow13.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow13.Controls.Add(this.label139);
            this.panel4TelemetryRow13.Controls.Add(this.label_RR_TireSteerAngle);
            this.panel4TelemetryRow13.Controls.Add(this.label61);
            this.panel4TelemetryRow13.Controls.Add(this.label_RR_CamberAngle);
            this.panel4TelemetryRow13.Controls.Add(this.label160);
            this.panel4TelemetryRow13.Location = new System.Drawing.Point(4, 343);
            this.panel4TelemetryRow13.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow13.Name = "panel4TelemetryRow13";
            this.panel4TelemetryRow13.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow13.TabIndex = 13;
            // 
            // label139
            // 
            this.label139.ForeColor = System.Drawing.Color.White;
            this.label139.Location = new System.Drawing.Point(4, 2);
            this.label139.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(158, 22);
            this.label139.TabIndex = 326;
            this.label139.Text = "Steer/Camber Angle";
            // 
            // label_RR_TireSteerAngle
            // 
            this.label_RR_TireSteerAngle.BackColor = System.Drawing.Color.Black;
            this.label_RR_TireSteerAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_TireSteerAngle.ForeColor = System.Drawing.Color.White;
            this.label_RR_TireSteerAngle.Location = new System.Drawing.Point(165, 2);
            this.label_RR_TireSteerAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_TireSteerAngle.Name = "label_RR_TireSteerAngle";
            this.label_RR_TireSteerAngle.Size = new System.Drawing.Size(220, 22);
            this.label_RR_TireSteerAngle.TabIndex = 137;
            this.label_RR_TireSteerAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.Color.Black;
            this.label61.ForeColor = System.Drawing.Color.White;
            this.label61.Location = new System.Drawing.Point(389, 2);
            this.label61.MinimumSize = new System.Drawing.Size(0, 31);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(27, 31);
            this.label61.TabIndex = 61;
            this.label61.Text = " /";
            // 
            // label_RR_CamberAngle
            // 
            this.label_RR_CamberAngle.BackColor = System.Drawing.Color.Black;
            this.label_RR_CamberAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_CamberAngle.ForeColor = System.Drawing.Color.White;
            this.label_RR_CamberAngle.Location = new System.Drawing.Point(420, 2);
            this.label_RR_CamberAngle.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_CamberAngle.Name = "label_RR_CamberAngle";
            this.label_RR_CamberAngle.Size = new System.Drawing.Size(220, 22);
            this.label_RR_CamberAngle.TabIndex = 138;
            this.label_RR_CamberAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label160
            // 
            this.label160.BackColor = System.Drawing.Color.Black;
            this.label160.ForeColor = System.Drawing.Color.White;
            this.label160.Location = new System.Drawing.Point(644, 2);
            this.label160.MinimumSize = new System.Drawing.Size(0, 31);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(23, 31);
            this.label160.TabIndex = 333;
            this.label160.Text = "°";
            // 
            // panel4TelemetryRow14
            // 
            this.panel4TelemetryRow14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow14.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow14.Controls.Add(this.label202);
            this.panel4TelemetryRow14.Controls.Add(this.label_RR_Mx);
            this.panel4TelemetryRow14.Controls.Add(this.label201);
            this.panel4TelemetryRow14.Controls.Add(this.label_RR_Mz);
            this.panel4TelemetryRow14.Controls.Add(this.label200);
            this.panel4TelemetryRow14.Controls.Add(this.label_RR_My);
            this.panel4TelemetryRow14.Location = new System.Drawing.Point(4, 369);
            this.panel4TelemetryRow14.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow14.Name = "panel4TelemetryRow14";
            this.panel4TelemetryRow14.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow14.TabIndex = 14;
            // 
            // label202
            // 
            this.label202.ForeColor = System.Drawing.Color.White;
            this.label202.Location = new System.Drawing.Point(4, 2);
            this.label202.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label202.MinimumSize = new System.Drawing.Size(0, 31);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(158, 31);
            this.label202.TabIndex = 329;
            this.label202.Text = "Mx/Mz/My";
            // 
            // label_RR_Mx
            // 
            this.label_RR_Mx.BackColor = System.Drawing.Color.Black;
            this.label_RR_Mx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_Mx.ForeColor = System.Drawing.Color.White;
            this.label_RR_Mx.Location = new System.Drawing.Point(165, 2);
            this.label_RR_Mx.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_Mx.Name = "label_RR_Mx";
            this.label_RR_Mx.Size = new System.Drawing.Size(145, 22);
            this.label_RR_Mx.TabIndex = 326;
            this.label_RR_Mx.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label201
            // 
            this.label201.BackColor = System.Drawing.Color.Black;
            this.label201.ForeColor = System.Drawing.Color.White;
            this.label201.Location = new System.Drawing.Point(314, 2);
            this.label201.MinimumSize = new System.Drawing.Size(0, 31);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(27, 31);
            this.label201.TabIndex = 330;
            this.label201.Text = " /";
            // 
            // label_RR_Mz
            // 
            this.label_RR_Mz.BackColor = System.Drawing.Color.Black;
            this.label_RR_Mz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_Mz.ForeColor = System.Drawing.Color.White;
            this.label_RR_Mz.Location = new System.Drawing.Point(345, 2);
            this.label_RR_Mz.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_Mz.Name = "label_RR_Mz";
            this.label_RR_Mz.Size = new System.Drawing.Size(145, 22);
            this.label_RR_Mz.TabIndex = 327;
            this.label_RR_Mz.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label200
            // 
            this.label200.BackColor = System.Drawing.Color.Black;
            this.label200.ForeColor = System.Drawing.Color.White;
            this.label200.Location = new System.Drawing.Point(494, 2);
            this.label200.MinimumSize = new System.Drawing.Size(0, 31);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(27, 31);
            this.label200.TabIndex = 331;
            this.label200.Text = " /";
            // 
            // label_RR_My
            // 
            this.label_RR_My.BackColor = System.Drawing.Color.Black;
            this.label_RR_My.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_My.ForeColor = System.Drawing.Color.White;
            this.label_RR_My.Location = new System.Drawing.Point(525, 2);
            this.label_RR_My.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_My.Name = "label_RR_My";
            this.label_RR_My.Size = new System.Drawing.Size(145, 22);
            this.label_RR_My.TabIndex = 328;
            this.label_RR_My.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel4TelemetryRow15
            // 
            this.panel4TelemetryRow15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4TelemetryRow15.BackColor = System.Drawing.Color.Black;
            this.panel4TelemetryRow15.Controls.Add(this.label207);
            this.panel4TelemetryRow15.Controls.Add(this.label_RR_PneumaticTrail);
            this.panel4TelemetryRow15.Controls.Add(this.label205);
            this.panel4TelemetryRow15.Controls.Add(this.label_RR_RollingResistance);
            this.panel4TelemetryRow15.Location = new System.Drawing.Point(4, 395);
            this.panel4TelemetryRow15.Margin = new System.Windows.Forms.Padding(0);
            this.panel4TelemetryRow15.Name = "panel4TelemetryRow15";
            this.panel4TelemetryRow15.Size = new System.Drawing.Size(436, 24);
            this.panel4TelemetryRow15.TabIndex = 15;
            // 
            // label207
            // 
            this.label207.ForeColor = System.Drawing.Color.White;
            this.label207.Location = new System.Drawing.Point(4, 2);
            this.label207.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label207.MinimumSize = new System.Drawing.Size(0, 31);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(158, 31);
            this.label207.TabIndex = 337;
            this.label207.Text = "Pt/Rr";
            // 
            // label_RR_PneumaticTrail
            // 
            this.label_RR_PneumaticTrail.BackColor = System.Drawing.Color.Black;
            this.label_RR_PneumaticTrail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_PneumaticTrail.ForeColor = System.Drawing.Color.White;
            this.label_RR_PneumaticTrail.Location = new System.Drawing.Point(165, 2);
            this.label_RR_PneumaticTrail.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_PneumaticTrail.Name = "label_RR_PneumaticTrail";
            this.label_RR_PneumaticTrail.Size = new System.Drawing.Size(220, 22);
            this.label_RR_PneumaticTrail.TabIndex = 338;
            this.label_RR_PneumaticTrail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label205
            // 
            this.label205.BackColor = System.Drawing.Color.Black;
            this.label205.ForeColor = System.Drawing.Color.White;
            this.label205.Location = new System.Drawing.Point(389, 2);
            this.label205.MinimumSize = new System.Drawing.Size(0, 31);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(44, 31);
            this.label205.TabIndex = 339;
            this.label205.Text = "m /";
            // 
            // label_RR_RollingResistance
            // 
            this.label_RR_RollingResistance.BackColor = System.Drawing.Color.Black;
            this.label_RR_RollingResistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_RR_RollingResistance.ForeColor = System.Drawing.Color.White;
            this.label_RR_RollingResistance.Location = new System.Drawing.Point(437, 2);
            this.label_RR_RollingResistance.Margin = new System.Windows.Forms.Padding(6);
            this.label_RR_RollingResistance.Name = "label_RR_RollingResistance";
            this.label_RR_RollingResistance.Size = new System.Drawing.Size(220, 22);
            this.label_RR_RollingResistance.TabIndex = 337;
            this.label_RR_RollingResistance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // debugWorkspacePanel
            // 
            this.debugWorkspacePanel.AutoScroll = true;
            this.debugWorkspacePanel.BackColor = System.Drawing.Color.Black;
            this.debugWorkspacePanel.Controls.Add(this.debug1Section);
            this.debugWorkspacePanel.Controls.Add(this.debug2Section);
            this.debugWorkspacePanel.Controls.Add(this.debug3Section);
            this.debugWorkspacePanel.Controls.Add(this.debug4Section);
            this.debugWorkspacePanel.Controls.Add(this.debug5Section);
            this.debugWorkspacePanel.Controls.Add(this.debug6Section);
            this.debugWorkspacePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugWorkspacePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.debugWorkspacePanel.Location = new System.Drawing.Point(0, 0);
            this.debugWorkspacePanel.Name = "debugWorkspacePanel";
            this.debugWorkspacePanel.Padding = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.debugWorkspacePanel.Size = new System.Drawing.Size(388, 1368);
            this.debugWorkspacePanel.TabIndex = 0;
            this.debugWorkspacePanel.WrapContents = false;
            // 
            // debug1Section
            // 
            this.debug1Section.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.debug1Section.Controls.Add(this.label16);
            this.debug1Section.Controls.Add(this.textBox1);
            this.debug1Section.ForeColor = System.Drawing.Color.White;
            this.debug1Section.Location = new System.Drawing.Point(6, 8);
            this.debug1Section.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.debug1Section.Name = "debug1Section";
            this.debug1Section.Size = new System.Drawing.Size(320, 116);
            this.debug1Section.TabIndex = 0;
            this.debug1Section.TabStop = false;
            this.debug1Section.Text = "Transform xyz";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(1646, 9);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(148, 25);
            this.label16.TabIndex = 263;
            this.label16.Text = "Transform xyz";
            this.label16.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(8, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 84);
            this.textBox1.TabIndex = 258;
            this.textBox1.Visible = false;
            // 
            // debug2Section
            // 
            this.debug2Section.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.debug2Section.Controls.Add(this.label17);
            this.debug2Section.Controls.Add(this.textBox2);
            this.debug2Section.ForeColor = System.Drawing.Color.White;
            this.debug2Section.Location = new System.Drawing.Point(6, 132);
            this.debug2Section.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.debug2Section.Name = "debug2Section";
            this.debug2Section.Size = new System.Drawing.Size(320, 116);
            this.debug2Section.TabIndex = 1;
            this.debug2Section.TabStop = false;
            this.debug2Section.Text = "Rotation 1 xyz??";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(1858, 9);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(173, 25);
            this.label17.TabIndex = 264;
            this.label17.Text = "Rotation 1 xyz??";
            this.label17.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.AcceptsReturn = true;
            this.textBox2.AcceptsTab = true;
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(8, 22);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(300, 84);
            this.textBox2.TabIndex = 259;
            this.textBox2.Visible = false;
            // 
            // debug3Section
            // 
            this.debug3Section.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.debug3Section.Controls.Add(this.label22);
            this.debug3Section.Controls.Add(this.textBox3);
            this.debug3Section.ForeColor = System.Drawing.Color.White;
            this.debug3Section.Location = new System.Drawing.Point(6, 256);
            this.debug3Section.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.debug3Section.Name = "debug3Section";
            this.debug3Section.Size = new System.Drawing.Size(320, 116);
            this.debug3Section.TabIndex = 2;
            this.debug3Section.TabStop = false;
            this.debug3Section.Text = "Rotation 2 xyz??";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(2076, 9);
            this.label22.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(173, 25);
            this.label22.TabIndex = 265;
            this.label22.Text = "Rotation 2 xyz??";
            this.label22.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.AcceptsReturn = true;
            this.textBox3.AcceptsTab = true;
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(8, 22);
            this.textBox3.Margin = new System.Windows.Forms.Padding(6);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(300, 84);
            this.textBox3.TabIndex = 260;
            this.textBox3.Visible = false;
            // 
            // debug4Section
            // 
            this.debug4Section.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.debug4Section.Controls.Add(this.label23);
            this.debug4Section.Controls.Add(this.textBox4);
            this.debug4Section.ForeColor = System.Drawing.Color.White;
            this.debug4Section.Location = new System.Drawing.Point(6, 380);
            this.debug4Section.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.debug4Section.Name = "debug4Section";
            this.debug4Section.Size = new System.Drawing.Size(320, 116);
            this.debug4Section.TabIndex = 3;
            this.debug4Section.TabStop = false;
            this.debug4Section.Text = "Rotation 3 xyz??";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(2298, 9);
            this.label23.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(173, 25);
            this.label23.TabIndex = 266;
            this.label23.Text = "Rotation 3 xyz??";
            this.label23.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.AcceptsReturn = true;
            this.textBox4.AcceptsTab = true;
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(8, 22);
            this.textBox4.Margin = new System.Windows.Forms.Padding(6);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(300, 84);
            this.textBox4.TabIndex = 261;
            this.textBox4.Visible = false;
            // 
            // debug5Section
            // 
            this.debug5Section.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.debug5Section.Controls.Add(this.label37);
            this.debug5Section.Controls.Add(this.textBox5);
            this.debug5Section.ForeColor = System.Drawing.Color.White;
            this.debug5Section.Location = new System.Drawing.Point(6, 504);
            this.debug5Section.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.debug5Section.Name = "debug5Section";
            this.debug5Section.Size = new System.Drawing.Size(320, 160);
            this.debug5Section.TabIndex = 4;
            this.debug5Section.TabStop = false;
            this.debug5Section.Text = "Quaternions?";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(2520, 9);
            this.label37.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(141, 25);
            this.label37.TabIndex = 267;
            this.label37.Text = "Quaternions?";
            this.label37.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.AcceptsReturn = true;
            this.textBox5.AcceptsTab = true;
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(8, 22);
            this.textBox5.Margin = new System.Windows.Forms.Padding(6);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(300, 128);
            this.textBox5.TabIndex = 262;
            this.textBox5.Visible = false;
            // 
            // debug6Section
            // 
            this.debug6Section.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.debug6Section.Controls.Add(this.textBox6);
            this.debug6Section.ForeColor = System.Drawing.Color.White;
            this.debug6Section.Location = new System.Drawing.Point(6, 672);
            this.debug6Section.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.debug6Section.Name = "debug6Section";
            this.debug6Section.Size = new System.Drawing.Size(320, 315);
            this.debug6Section.TabIndex = 5;
            this.debug6Section.TabStop = false;
            this.debug6Section.Text = "Scratch / test output";
            // 
            // textBox6
            // 
            this.textBox6.AcceptsReturn = true;
            this.textBox6.AcceptsTab = true;
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Location = new System.Drawing.Point(8, 22);
            this.textBox6.Margin = new System.Windows.Forms.Padding(6);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(300, 283);
            this.textBox6.TabIndex = 268;
            this.textBox6.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonUpdates
            // 
            this.buttonUpdates.Enabled = true;
            this.buttonUpdates.Interval = 500;
            this.buttonUpdates.Tick += new System.EventHandler(this.buttonUpdates_Tick);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(15, 9);
            this.label38.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(214, 25);
            this.label38.TabIndex = 286;
            this.label38.Text = "Select Game Version";
            this.label38.Visible = false;
            // 
            // FormLiveData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1871, 1439);
            this.Controls.Add(this.liveDataMainLayout);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormLiveData";
            this.Text = "Live Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FirstAllDataLoggerPage_Closing);
            this.Load += new System.EventHandler(this.FirstAllDataLoggerPage_Load);
            this.liveDataMainLayout.ResumeLayout(false);
            this.navigationPagesPanel.ResumeLayout(false);
            this.telemetrySidebarSplitter.Panel1.ResumeLayout(false);
            this.telemetrySidebarSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.telemetrySidebarSplitter)).EndInit();
            this.telemetrySidebarSplitter.ResumeLayout(false);
            this.telemetrySidebarPanel.ResumeLayout(false);
            this.telemetrySidebarPanel.PerformLayout();
            this.sidebarSectionsLayout.ResumeLayout(false);
            this.gameVersionSection.ResumeLayout(false);
            this.gameVersionFieldsLayout.ResumeLayout(false);
            this.sessionLoggingSection.ResumeLayout(false);
            this.sessionLoggingSection.PerformLayout();
            this.speedTelemetrySection.ResumeLayout(false);
            this.speedTelemetrySection.PerformLayout();
            this.accelerationTelemetrySection.ResumeLayout(false);
            this.accelerationTelemetrySection.PerformLayout();
            this.gforceTelemetrySection.ResumeLayout(false);
            this.gforceTelemetrySection.PerformLayout();
            this.aeroTelemetrySection.ResumeLayout(false);
            this.liftTelemetrySection.ResumeLayout(false);
            this.liftTelemetrySection.PerformLayout();
            this.engineTelemetrySection.ResumeLayout(false);
            this.engineTelemetrySection.PerformLayout();
            this.differentialTelemetrySection.ResumeLayout(false);
            this.differentialTelemetrySection.PerformLayout();
            this.differentialLeftSection.ResumeLayout(false);
            this.differentialLeftSection.PerformLayout();
            this.differentialRightSection.ResumeLayout(false);
            this.differentialRightSection.PerformLayout();
            this.debugWorkspaceSplitter.Panel1.ResumeLayout(false);
            this.debugWorkspaceSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.debugWorkspaceSplitter)).EndInit();
            this.debugWorkspaceSplitter.ResumeLayout(false);
            this.wheelTelemetryColumn.ResumeLayout(false);
            this.fourWheelScrollPanel.ResumeLayout(false);
            this.fourWheelGrid.ResumeLayout(false);
            this.panel1TelemetryCard.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1TelemetryRow0.ResumeLayout(false);
            this.panel1TelemetryRow1.ResumeLayout(false);
            this.panel1TelemetryRow2.ResumeLayout(false);
            this.panel1TelemetryRow3.ResumeLayout(false);
            this.panel1TelemetryRow4.ResumeLayout(false);
            this.panel1TelemetryRow5.ResumeLayout(false);
            this.panel1TelemetryRow6.ResumeLayout(false);
            this.panel1TelemetryRow7.ResumeLayout(false);
            this.panel1TelemetryRow8.ResumeLayout(false);
            this.panel1TelemetryRow9.ResumeLayout(false);
            this.panel1TelemetryRow10.ResumeLayout(false);
            this.panel1TelemetryRow11.ResumeLayout(false);
            this.panel1TelemetryRow12.ResumeLayout(false);
            this.panel1TelemetryRow13.ResumeLayout(false);
            this.panel1TelemetryRow14.ResumeLayout(false);
            this.panel1TelemetryRow15.ResumeLayout(false);
            this.panel2TelemetryCard.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2TelemetryRow0.ResumeLayout(false);
            this.panel2TelemetryRow1.ResumeLayout(false);
            this.panel2TelemetryRow2.ResumeLayout(false);
            this.panel2TelemetryRow3.ResumeLayout(false);
            this.panel2TelemetryRow4.ResumeLayout(false);
            this.panel2TelemetryRow5.ResumeLayout(false);
            this.panel2TelemetryRow6.ResumeLayout(false);
            this.panel2TelemetryRow7.ResumeLayout(false);
            this.panel2TelemetryRow8.ResumeLayout(false);
            this.panel2TelemetryRow9.ResumeLayout(false);
            this.panel2TelemetryRow10.ResumeLayout(false);
            this.panel2TelemetryRow11.ResumeLayout(false);
            this.panel2TelemetryRow12.ResumeLayout(false);
            this.panel2TelemetryRow13.ResumeLayout(false);
            this.panel2TelemetryRow14.ResumeLayout(false);
            this.panel2TelemetryRow15.ResumeLayout(false);
            this.panel3TelemetryCard.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3TelemetryRow0.ResumeLayout(false);
            this.panel3TelemetryRow1.ResumeLayout(false);
            this.panel3TelemetryRow2.ResumeLayout(false);
            this.panel3TelemetryRow3.ResumeLayout(false);
            this.panel3TelemetryRow4.ResumeLayout(false);
            this.panel3TelemetryRow5.ResumeLayout(false);
            this.panel3TelemetryRow6.ResumeLayout(false);
            this.panel3TelemetryRow7.ResumeLayout(false);
            this.panel3TelemetryRow8.ResumeLayout(false);
            this.panel3TelemetryRow9.ResumeLayout(false);
            this.panel3TelemetryRow10.ResumeLayout(false);
            this.panel3TelemetryRow11.ResumeLayout(false);
            this.panel3TelemetryRow12.ResumeLayout(false);
            this.panel3TelemetryRow13.ResumeLayout(false);
            this.panel3TelemetryRow14.ResumeLayout(false);
            this.panel3TelemetryRow15.ResumeLayout(false);
            this.panel4TelemetryCard.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4TelemetryRow0.ResumeLayout(false);
            this.panel4TelemetryRow1.ResumeLayout(false);
            this.panel4TelemetryRow2.ResumeLayout(false);
            this.panel4TelemetryRow3.ResumeLayout(false);
            this.panel4TelemetryRow4.ResumeLayout(false);
            this.panel4TelemetryRow5.ResumeLayout(false);
            this.panel4TelemetryRow6.ResumeLayout(false);
            this.panel4TelemetryRow7.ResumeLayout(false);
            this.panel4TelemetryRow8.ResumeLayout(false);
            this.panel4TelemetryRow9.ResumeLayout(false);
            this.panel4TelemetryRow10.ResumeLayout(false);
            this.panel4TelemetryRow11.ResumeLayout(false);
            this.panel4TelemetryRow12.ResumeLayout(false);
            this.panel4TelemetryRow13.ResumeLayout(false);
            this.panel4TelemetryRow14.ResumeLayout(false);
            this.panel4TelemetryRow15.ResumeLayout(false);
            this.debugWorkspacePanel.ResumeLayout(false);
            this.debug1Section.ResumeLayout(false);
            this.debug1Section.PerformLayout();
            this.debug2Section.ResumeLayout(false);
            this.debug2Section.PerformLayout();
            this.debug3Section.ResumeLayout(false);
            this.debug3Section.PerformLayout();
            this.debug4Section.ResumeLayout(false);
            this.debug4Section.PerformLayout();
            this.debug5Section.ResumeLayout(false);
            this.debug5Section.PerformLayout();
            this.debug6Section.ResumeLayout(false);
            this.debug6Section.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label_FL_AngularVelocity;
        private System.Windows.Forms.Label label_FL_TreadTemperature;
        private System.Windows.Forms.Label label_FL_InnerTemperature;
        private System.Windows.Forms.Label label_FL_Deflection;
        private System.Windows.Forms.Label label_FL_LoadedRadius;
        private System.Windows.Forms.Label label_FL_EffectiveRadius;
        private System.Windows.Forms.Label label_FL_CurrentContactBrakeTorque;
        private System.Windows.Forms.Label label_FL_VerticalLoad;
        private System.Windows.Forms.Label label_FL_LateralLoad;
        private System.Windows.Forms.Label label_FL_LongitudinalLoad;
        private System.Windows.Forms.Label label_FL_SlipAngleDeg;
        private System.Windows.Forms.Label label_FL_SlipRatio;
        private System.Windows.Forms.Label label_FL_ContactLength;
        private System.Windows.Forms.Label label_FL_TravelSpeed;
        private System.Windows.Forms.Label label_FL_LateralFriction;
        private System.Windows.Forms.Label label_FL_LongitudinalFriction;
        private System.Windows.Forms.Label label_FR_LongitudinalFriction;
        private System.Windows.Forms.Label label_FR_LateralFriction;
        private System.Windows.Forms.Label label_FR_TravelSpeed;
        private System.Windows.Forms.Label label_FR_ContactLength;
        private System.Windows.Forms.Label label_FR_SlipRatio;
        private System.Windows.Forms.Label label_FR_SlipAngleDeg;
        private System.Windows.Forms.Label label_FR_LongitudinalLoad;
        private System.Windows.Forms.Label label_FR_LateralLoad;
        private System.Windows.Forms.Label label_FR_VerticalLoad;
        private System.Windows.Forms.Label label_FR_CurrentContactBrakeTorque;
        private System.Windows.Forms.Label label_FR_EffectiveRadius;
        private System.Windows.Forms.Label label_FR_LoadedRadius;
        private System.Windows.Forms.Label label_FR_Deflection;
        private System.Windows.Forms.Label label_FR_InnerTemperature;
        private System.Windows.Forms.Label label_FR_TreadTemperature;
        private System.Windows.Forms.Label label_FR_AngularVelocity;
        private System.Windows.Forms.Label label_RL_LongitudinalFriction;
        private System.Windows.Forms.Label label_RL_LateralFriction;
        private System.Windows.Forms.Label label_RL_TravelSpeed;
        private System.Windows.Forms.Label label_RL_ContactLength;
        private System.Windows.Forms.Label label_RL_SlipRatio;
        private System.Windows.Forms.Label label_RL_SlipAngleDeg;
        private System.Windows.Forms.Label label_RL_LongitudinalLoad;
        private System.Windows.Forms.Label label_RL_LateralLoad;
        private System.Windows.Forms.Label label_RL_VerticalLoad;
        private System.Windows.Forms.Label label_RL_CurrentContactBrakeTorque;
        private System.Windows.Forms.Label label_RL_EffectiveRadius;
        private System.Windows.Forms.Label label_RL_LoadedRadius;
        private System.Windows.Forms.Label label_RL_Deflection;
        private System.Windows.Forms.Label label_RL_InnerTemperature;
        private System.Windows.Forms.Label label_RL_TreadTemperature;
        private System.Windows.Forms.Label label_RL_AngularVelocity;
        private System.Windows.Forms.Label label_RR_LongitudinalFriction;
        private System.Windows.Forms.Label label_RR_LateralFriction;
        private System.Windows.Forms.Label label_RR_TravelSpeed;
        private System.Windows.Forms.Label label_RR_ContactLength;
        private System.Windows.Forms.Label label_RR_SlipRatio;
        private System.Windows.Forms.Label label_RR_SlipAngleDeg;
        private System.Windows.Forms.Label label_RR_LongitudinalLoad;
        private System.Windows.Forms.Label label_RR_LateralLoad;
        private System.Windows.Forms.Label label_RR_VerticalLoad;
        private System.Windows.Forms.Label label_RR_CurrentContactBrakeTorque;
        private System.Windows.Forms.Label label_RR_EffectiveRadius;
        private System.Windows.Forms.Label label_RR_LoadedRadius;
        private System.Windows.Forms.Label label_RR_Deflection;
        private System.Windows.Forms.Label label_RR_InnerTemperature;
        private System.Windows.Forms.Label label_RR_TreadTemperature;
        private System.Windows.Forms.Label label_RR_AngularVelocity;
        private System.Windows.Forms.Button startFileLoggingButton;
        public System.Windows.Forms.Label CurrentSpeed;
        public System.Windows.Forms.Label CurrentFrontLift;
        public System.Windows.Forms.Label CurrentRearLift;
        private System.Windows.Forms.TextBox logInterval_textBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label_FL_LateralSlipSpeed;
        private System.Windows.Forms.Label label_FL_LongitudinalSlipSpeed;
        private System.Windows.Forms.Label label_FL_TireSteerAngle;
        private System.Windows.Forms.Label label_FL_CamberAngle;
        private System.Windows.Forms.Label label_FR_CamberAngle;
        private System.Windows.Forms.Label label_FR_TireSteerAngle;
        private System.Windows.Forms.Label label_FR_LongitudinalSlipSpeed;
        private System.Windows.Forms.Label label_FR_LateralSlipSpeed;
        private System.Windows.Forms.Label label_RL_CamberAngle;
        private System.Windows.Forms.Label label_RL_TireSteerAngle;
        private System.Windows.Forms.Label label_RL_LongitudinalSlipSpeed;
        private System.Windows.Forms.Label label_RL_LateralSlipSpeed;
        private System.Windows.Forms.Label label_RR_CamberAngle;
        private System.Windows.Forms.Label label_RR_TireSteerAngle;
        private System.Windows.Forms.Label label_RR_LongitudinalSlipSpeed;
        private System.Windows.Forms.Label label_RR_LateralSlipSpeed;
        private System.Windows.Forms.Label label_FL_TotalFrictionAngle;
        private System.Windows.Forms.Label label_FL_TotalFriction;
        private System.Windows.Forms.Label label_FR_TotalFrictionAngle;
        private System.Windows.Forms.Label label_FR_TotalFriction;
        private System.Windows.Forms.Label label_RL_TotalFrictionAngle;
        private System.Windows.Forms.Label label_RL_TotalFriction;
        private System.Windows.Forms.Label label_RR_TotalFrictionAngle;
        private System.Windows.Forms.Label label_RR_TotalFriction;
        private System.Windows.Forms.Button toLogSettingsButton;
        private System.Windows.Forms.Label label_FL_MaxCurrentContactBrakeTorque;
        private System.Windows.Forms.Label label_FR_MaxCurrentContactBrakeTorque;
        private System.Windows.Forms.Label label_RL_MaxCurrentContactBrakeTorque;
        private System.Windows.Forms.Label label_RR_MaxCurrentContactBrakeTorque;
        private System.Windows.Forms.Button toTireStaticValues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label TickTime;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label_FL_SuspensionVelocity;
        private System.Windows.Forms.Label label_FL_SuspensionLength;
        private System.Windows.Forms.Label label_FR_SuspensionVelocity;
        private System.Windows.Forms.Label label_FR_SuspensionLength;
        private System.Windows.Forms.Label label_RL_SuspensionVelocity;
        private System.Windows.Forms.Label label_RL_SuspensionLength;
        private System.Windows.Forms.Label label_RR_SuspensionVelocity;
        private System.Windows.Forms.Label label_RR_SuspensionLength;
        private System.Windows.Forms.Button toSuspensionStaticValues;
        private System.Windows.Forms.Button OpenTemperaturesChart;
        public System.Windows.Forms.Label CurrentEngineTorque;
        public System.Windows.Forms.Label CurrentEnginePower;
        public System.Windows.Forms.Label CurrentLeftDifferentialOpen;
        private System.Windows.Forms.Label Differential;
        public System.Windows.Forms.Label CurrentLeftDifferentialSpeedRad;
        public System.Windows.Forms.Label CurrentLeftDifferentialTorque;
        public System.Windows.Forms.Label CurrentEngineRPM;
        private System.Windows.Forms.Label label78;
        public System.Windows.Forms.Label CurrentEngineRPMAxle;
        private System.Windows.Forms.Button toTestChartPageButton;
        public System.Windows.Forms.Label CurrentAcceleration;
        private System.Windows.Forms.Label label75;
        public System.Windows.Forms.Label CurrentGForce;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Button getProcessButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button toGForceButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer buttonUpdates;
        private System.Windows.Forms.Button to4WheelsButton;
        public System.Windows.Forms.Label CurrentYDrag;
        public System.Windows.Forms.Label CurrentXDrag;
        public System.Windows.Forms.Label CurrentZDrag;
        public System.Windows.Forms.Label CurrentTotalDrag;
        private System.Windows.Forms.Label LeftLabel;
        private System.Windows.Forms.Label RightLabel;
        public System.Windows.Forms.Label CurrentRightDifferentialTorque;
        public System.Windows.Forms.Label CurrentRightDifferentialSpeedRad;
        public System.Windows.Forms.Label CurrentRightDifferentialOpen;
        private System.Windows.Forms.ComboBox GameVersionComboBox;
        public System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button toSuspensionGeometry;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label146;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.Label label147;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label148;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.Label label149;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label150;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.Label label151;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label152;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.Label label153;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label154;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.Label label155;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label156;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Label label157;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label158;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label label159;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.Label label130;
        private System.Windows.Forms.Label label160;
        private System.Windows.Forms.Label label132;
        private System.Windows.Forms.Label label161;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label162;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.Label label163;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label164;
        private System.Windows.Forms.Label label134;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.Label label135;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label168;
        private System.Windows.Forms.Label label136;
        private System.Windows.Forms.Label label169;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.Label label170;
        private System.Windows.Forms.Label label137;
        private System.Windows.Forms.Label label171;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label172;
        private System.Windows.Forms.Label label138;
        private System.Windows.Forms.Label label173;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Label label139;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label142;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label143;
        private System.Windows.Forms.Label label144;
        private System.Windows.Forms.Label label145;
        private System.Windows.Forms.Label label184;
        private System.Windows.Forms.Label label183;
        private System.Windows.Forms.Label label182;
        private System.Windows.Forms.Label label181;
        private System.Windows.Forms.Label label180;
        private System.Windows.Forms.Label label179;
        private System.Windows.Forms.Label label178;
        private System.Windows.Forms.Label label177;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.Label label175;
        private System.Windows.Forms.Label label174;
        private System.Windows.Forms.Label label190;
        private System.Windows.Forms.Label label189;
        private System.Windows.Forms.Label label188;
        private System.Windows.Forms.Label label_FL_My;
        private System.Windows.Forms.Label label_FL_Mz;
        private System.Windows.Forms.Label label_FL_Mx;
        private System.Windows.Forms.Label label185;
        private System.Windows.Forms.Label label186;
        private System.Windows.Forms.Label label187;
        private System.Windows.Forms.Label label_FR_My;
        private System.Windows.Forms.Label label_FR_Mz;
        private System.Windows.Forms.Label label_FR_Mx;
        private System.Windows.Forms.Label label194;
        private System.Windows.Forms.Label label195;
        private System.Windows.Forms.Label label196;
        private System.Windows.Forms.Label label_RL_My;
        private System.Windows.Forms.Label label_RL_Mz;
        private System.Windows.Forms.Label label_RL_Mx;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.Label label202;
        private System.Windows.Forms.Label label_RR_My;
        private System.Windows.Forms.Label label_RR_Mz;
        private System.Windows.Forms.Label label_RR_Mx;
        private System.Windows.Forms.Label label193;
        private System.Windows.Forms.Label label_FL_PneumaticTrail;
        private System.Windows.Forms.Label label191;
        private System.Windows.Forms.Label label192;
        private System.Windows.Forms.Label label_FR_PneumaticTrail;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.Label label_RL_PneumaticTrail;
        private System.Windows.Forms.Label label204;
        private System.Windows.Forms.Label label205;
        private System.Windows.Forms.Label label_RR_PneumaticTrail;
        private System.Windows.Forms.Label label207;
        private System.Windows.Forms.Label label_FL_RollingResistance;
        private System.Windows.Forms.Label label_FR_RollingResistance;
        private System.Windows.Forms.Label label_RL_RollingResistance;
        private System.Windows.Forms.Label label_RR_RollingResistance;
        private System.Windows.Forms.TableLayoutPanel liveDataMainLayout;
        private System.Windows.Forms.FlowLayoutPanel navigationPagesPanel;
        private System.Windows.Forms.SplitContainer telemetrySidebarSplitter;
        private System.Windows.Forms.SplitContainer debugWorkspaceSplitter;
        private System.Windows.Forms.Panel telemetrySidebarPanel;
        private System.Windows.Forms.TableLayoutPanel sidebarSectionsLayout;
        private System.Windows.Forms.FlowLayoutPanel debugWorkspacePanel;
        private System.Windows.Forms.TableLayoutPanel wheelTelemetryColumn;
        private System.Windows.Forms.Panel fourWheelScrollPanel;
        private System.Windows.Forms.TableLayoutPanel fourWheelGrid;
        private System.Windows.Forms.Button openOfflineChartButton;
        private System.Windows.Forms.Button toggleDebugWorkspaceButton;
        private System.Windows.Forms.Button GameConfigurationProfilesButton;
        private System.Windows.Forms.Panel SettingsProfilesHost;
        private System.Windows.Forms.Label versionDetectionStatus;
        private System.Windows.Forms.GroupBox gameVersionSection;
        private System.Windows.Forms.TableLayoutPanel gameVersionFieldsLayout;
        private System.Windows.Forms.GroupBox sessionLoggingSection;
        private System.Windows.Forms.GroupBox speedTelemetrySection;
        private System.Windows.Forms.GroupBox accelerationTelemetrySection;
        private System.Windows.Forms.GroupBox gforceTelemetrySection;
        private System.Windows.Forms.GroupBox aeroTelemetrySection;
        private System.Windows.Forms.GroupBox liftTelemetrySection;
        private System.Windows.Forms.GroupBox engineTelemetrySection;
        private System.Windows.Forms.GroupBox differentialTelemetrySection;
        private System.Windows.Forms.GroupBox differentialLeftSection;
        private System.Windows.Forms.GroupBox differentialRightSection;
        private System.Windows.Forms.GroupBox debug1Section;
        private System.Windows.Forms.GroupBox debug2Section;
        private System.Windows.Forms.GroupBox debug3Section;
        private System.Windows.Forms.GroupBox debug4Section;
        private System.Windows.Forms.GroupBox debug5Section;
        private System.Windows.Forms.GroupBox debug6Section;
        private System.Windows.Forms.GroupBox panel1TelemetryCard;
        private System.Windows.Forms.Panel panel1TelemetryRow0;
        private System.Windows.Forms.Panel panel1TelemetryRow1;
        private System.Windows.Forms.Panel panel1TelemetryRow2;
        private System.Windows.Forms.Panel panel1TelemetryRow3;
        private System.Windows.Forms.Panel panel1TelemetryRow4;
        private System.Windows.Forms.Panel panel1TelemetryRow5;
        private System.Windows.Forms.Panel panel1TelemetryRow6;
        private System.Windows.Forms.Panel panel1TelemetryRow7;
        private System.Windows.Forms.Panel panel1TelemetryRow8;
        private System.Windows.Forms.Panel panel1TelemetryRow9;
        private System.Windows.Forms.Panel panel1TelemetryRow10;
        private System.Windows.Forms.Panel panel1TelemetryRow11;
        private System.Windows.Forms.Panel panel1TelemetryRow12;
        private System.Windows.Forms.Panel panel1TelemetryRow13;
        private System.Windows.Forms.Panel panel1TelemetryRow14;
        private System.Windows.Forms.Panel panel1TelemetryRow15;
        private System.Windows.Forms.GroupBox panel2TelemetryCard;
        private System.Windows.Forms.Panel panel2TelemetryRow0;
        private System.Windows.Forms.Panel panel2TelemetryRow1;
        private System.Windows.Forms.Panel panel2TelemetryRow2;
        private System.Windows.Forms.Panel panel2TelemetryRow3;
        private System.Windows.Forms.Panel panel2TelemetryRow4;
        private System.Windows.Forms.Panel panel2TelemetryRow5;
        private System.Windows.Forms.Panel panel2TelemetryRow6;
        private System.Windows.Forms.Panel panel2TelemetryRow7;
        private System.Windows.Forms.Panel panel2TelemetryRow8;
        private System.Windows.Forms.Panel panel2TelemetryRow9;
        private System.Windows.Forms.Panel panel2TelemetryRow10;
        private System.Windows.Forms.Panel panel2TelemetryRow11;
        private System.Windows.Forms.Panel panel2TelemetryRow12;
        private System.Windows.Forms.Panel panel2TelemetryRow13;
        private System.Windows.Forms.Panel panel2TelemetryRow14;
        private System.Windows.Forms.Panel panel2TelemetryRow15;
        private System.Windows.Forms.GroupBox panel3TelemetryCard;
        private System.Windows.Forms.Panel panel3TelemetryRow0;
        private System.Windows.Forms.Panel panel3TelemetryRow1;
        private System.Windows.Forms.Panel panel3TelemetryRow2;
        private System.Windows.Forms.Panel panel3TelemetryRow3;
        private System.Windows.Forms.Panel panel3TelemetryRow4;
        private System.Windows.Forms.Panel panel3TelemetryRow5;
        private System.Windows.Forms.Panel panel3TelemetryRow6;
        private System.Windows.Forms.Panel panel3TelemetryRow7;
        private System.Windows.Forms.Panel panel3TelemetryRow8;
        private System.Windows.Forms.Panel panel3TelemetryRow9;
        private System.Windows.Forms.Panel panel3TelemetryRow10;
        private System.Windows.Forms.Panel panel3TelemetryRow11;
        private System.Windows.Forms.Panel panel3TelemetryRow12;
        private System.Windows.Forms.Panel panel3TelemetryRow13;
        private System.Windows.Forms.Panel panel3TelemetryRow14;
        private System.Windows.Forms.Panel panel3TelemetryRow15;
        private System.Windows.Forms.GroupBox panel4TelemetryCard;
        private System.Windows.Forms.Panel panel4TelemetryRow0;
        private System.Windows.Forms.Panel panel4TelemetryRow1;
        private System.Windows.Forms.Panel panel4TelemetryRow2;
        private System.Windows.Forms.Panel panel4TelemetryRow3;
        private System.Windows.Forms.Panel panel4TelemetryRow4;
        private System.Windows.Forms.Panel panel4TelemetryRow5;
        private System.Windows.Forms.Panel panel4TelemetryRow6;
        private System.Windows.Forms.Panel panel4TelemetryRow7;
        private System.Windows.Forms.Panel panel4TelemetryRow8;
        private System.Windows.Forms.Panel panel4TelemetryRow9;
        private System.Windows.Forms.Panel panel4TelemetryRow10;
        private System.Windows.Forms.Panel panel4TelemetryRow11;
        private System.Windows.Forms.Panel panel4TelemetryRow12;
        private System.Windows.Forms.Panel panel4TelemetryRow13;
        private System.Windows.Forms.Panel panel4TelemetryRow14;
        private System.Windows.Forms.Panel panel4TelemetryRow15;
    }
}

