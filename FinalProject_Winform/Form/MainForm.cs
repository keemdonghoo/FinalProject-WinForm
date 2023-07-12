﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Winform
{
    public partial class MainForm : Form
    {

        private LOTForm lotForm;

        public MainForm()
        {
            InitializeComponent();

            // 시리얼 포트 생성
            serialPort = new();
            serialPort.BaudRate = 9600;
            serialPort.DataReceived += serialPort_DataReceived;

            serialPort.ReadTimeout = 0;
        }
        private SerialPort serialPort;
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    while (true)
                    {
                        string input = "";
                        string recvData = serialPort.ReadLine().Trim();   // Trim() 꼭 해야 한다 
                        input = $"← {recvData}";
                        ExecCommand(recvData);
                    }
                }
                catch (TimeoutException) { }  // ReadTimeout = 0;  // 읽기 timeout (ms) 을 0 으로 하자.
            }
        }  
        
        //---------------------------------------
        // Command 에 따른 분기
        private void ExecCommand(string recvData)
        {
            if (recvData.Length == 0 || recvData[0] != '$') return;

            string[] arrMessage = recvData[1..].Split(",", StringSplitOptions.RemoveEmptyEntries);

            switch (arrMessage[0]) // Command
            {
                case "Recieve":
                    //ProcessReady();
                    break;
                case "Start":
                    //ProcessReject(arrMessage[1]);
                    break;
                case "Stop":
                    //ProcessAccept(arrMessage[1]);
                    break;
                case "End":
                    //ProcessProcess(arrMessage[1]);
                    break;
            } // end switch

        } // end ExecCommand()

        private void MainForm_Load(object sender, EventArgs e)
        {
            // MainForm이 로드될 때 수행할 작업
        }

        //버튼 클릭 이벤트 하나로 묶어둔 함수
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string formName = button.Name.Replace("btn_", "");
                FormUtility.OpenForm(formName, this);
            }
        }

        //닫으면 모든 폼 닫기 
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 숨겨진 폼을 담을 복사본 컬렉션 생성
            var hiddenForms = new List<Form>();

            // 숨겨진 모든 폼을 복사본 컬렉션에 추가
            foreach (Form form in Application.OpenForms)
            {
                if (form != this && !form.IsDisposed && !form.Visible)
                {
                    hiddenForms.Add(form);
                }
            }

            // 복사본 컬렉션의 폼 닫기
            foreach (Form form in hiddenForms)
            {
                form.Close();
            }
        }
    }
}
