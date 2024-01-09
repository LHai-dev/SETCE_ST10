VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "Form_frmEmployee"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Compare Database

Private Sub btnShow_Click()
    Dim str As String
    Dim bonus As Double
    Dim totalSalary As Double
    
    str = "ID :" & txtID.Value & _
    vbCrLf & "Name : " & txtName.Value & _
    vbCrLf & "Salary:" & txtSalary.Value
    
    str = str + vbCrLf + "Benefits: "
    If chkMed.Value = -1 Then
        str = str + vbCrLf + "Medical"
    End If
    If chkRet.Value = -1 Then
        str = str + vbCrLf + "Retirement"
    End If
    
    
    If frmPerf.Value = 1 Then
        bonus = txtSalary.Value * 0.1
    ElseIf frmPerf.Value = 2 Then
        bonus = txtSalary.Value * 0.09
    ElseIf frmPerf.Value = 3 Then
        bonus = txtSalary.Value * 0.07
    End If
    
    totalSalary = bonus + txtSalary.Value
    str = str + vbCrLf + "TotalSalary: $" & totalSalary
    
    MsgBox str
    
End Sub

Private Sub Form_Load()
    MsgBox "EmployeeData"
End Sub
