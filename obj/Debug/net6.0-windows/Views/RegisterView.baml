   M S B A M L   `   `   `  ����G  CTasksProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TasksProject.ViewsTasksProject.Views  5      I)clr-namespace:TasksProject.CustomControlsTasksProject.CustomControls  6=   %    TasksProject.Views.RegisterView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:TasksProject.Views     5      DcustomControls)clr-namespace:TasksProject.CustomControls     6=   .��5	      �� $
��auto��6   $	��400��6   $��Center=�6,   .+�5
   
   �� $��Register��6   $��50(�6$   $��	ExtraBold"�62   $��Center=�6J   $�� 0 40q�6g   �� 5   
   $��Username��6   $��30(�6$   $��Center=�62   $
��Bold"�6P   �� 5   
   $
��10 8q�6Q   $��16(�6`   $	��300��6n   $
��0 10q�6z   $��2q�6�   
���   ���6   �� *
Username+  �� UpdateSourceTrigger$  PropertyChanged=�6�   �� 5   
   $��Password��6   $��30(�6$   $��Center=�62   $
��Bold"�6O   $��	 0 10 0 0q�6a   2   ,TasksProject.CustomControls.BindablePassword  5   
      Password 6*   �� *
Password+ �� Mode$ TwoWay=�$  PropertyChanged=�6|   �� 5   
   $��Center=�6   $��	Is Admin?��60   $
��Bold"�6D   $
��0 20q�6V    d� 	IsChecked 6d   �� *	IsAdmin+ � LayoutTransform 5      �� 5       �� ScaleX$	 2.3Q�6!    �� ScaleY$	 2.3Q�6.   5      �� 5   
   $��Submit��6   $��25(�6"   $��Medium"�60   $��30 30 30 10q�6E   $	��350��6Z   $��45��6f      SubmitButtonTheme#��[  5   3   ��6
   �� *CreateAccountCommand+63   �� 5   
   $��Login��6   $��25(�6!   $��Medium"�6/   $��30 10 30 10q�6C   $	��350��6X   $��45��6d     MainButtonTheme#��[ 5   3   ��6
   �� *NavigateLoginCommand+63   5!      5"      