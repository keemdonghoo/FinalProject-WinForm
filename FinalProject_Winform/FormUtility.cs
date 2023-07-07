﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Winform
{
    public static class FormUtility
    {
        //버튼 값에 따라 Form 여는 함수
        public static void OpenForm(string formName, Form currentForm)
        {
            Form targetForm = null;

            switch (formName)
            {
                case "LOTForm":
                    targetForm = Application.OpenForms["LOTForm"] as LOTForm;
                    if (targetForm == null)
                    {
                        targetForm = new LOTForm();
                    }
                    break;
                case "TestForm":
                    targetForm = Application.OpenForms["TestForm"] as TestForm;
                    if (targetForm == null)
                    {
                        targetForm = new TestForm();
                    }
                    break;
                case "ProcessForm":
                    targetForm = Application.OpenForms["ProcessForm"] as ProcessForm;
                    if (targetForm == null)
                    {
                        targetForm = new ProcessForm();
                    }
                    break;
                case "StockForm":
                    targetForm = Application.OpenForms["StockForm"] as StockForm;
                    if (targetForm == null)
                    {
                        targetForm = new StockForm();
                    }
                    break;
                case "OrderForm":
                    targetForm = Application.OpenForms["OrderForm"] as OrderForm;
                    if (targetForm == null)
                    {
                        targetForm = new OrderForm();
                    }
                    break;
                case "ChartForm":
                    targetForm = Application.OpenForms["ChartForm"] as ChartForm;
                    if (targetForm == null)
                    {
                        targetForm = new ChartForm();
                    }
                    break;
                default:
                    break;
            }

            currentForm.Hide(); // 현재 폼 숨기기

            targetForm.Show(); // 타겟 폼 보여주기


        }
    }

}