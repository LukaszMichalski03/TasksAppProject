   M S B A M L   `   `   `  ����G  CTasksProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TasksProject.ComponentsTasksProject.Components  5      9!clr-namespace:TasksProject.ModelsTasksProject.Models  6B   *    $TasksProject.Components.TasksListing   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:TasksProject.Components     5      4models!clr-namespace:TasksProject.Models     6B     � 	Resources  5	      2   ,TasksProject.Models.BooleanToStringConverter   BooleanToStringConverter��%   &	          5
   
   6*   5      .��5      � .+�5   
   ��  �� SelectionMode$ Single=�5      ��5      �� *TasksListingItemViewModels+ �� SelectedItem 5      �� *" SelectedTaskListingItemViewModel+ �� Mode$ TwoWay=� �� View 5      �� 5      .P�5      �� $��
Task Title��6%    �� Width$	 200��69    �� CellTemplate 5      �� 5      .R�5   "   �� $
��Bold"�6C   $��20 0 0 0q�6U   $
��Wrap=�6g   ��6,   �� *Title+6g   5      5      �� 5      $��IsDone��6%   $
 auto��65    5      �� 5      .R�5   "   �� $��20 0 0 0q�6y   ��6,   �� *IsDone+ �� 	Converter# [  6y   5      5       5!        5#       �� 
TargetType	 �� Property
 �� Value �� Triggers P� Property P� Value��%�  '��       '�� N     '�� 5    �� 5$      " ��6   .�5%      �� 	 � ��
 �#61826463   5'      �� 5(      " ��6   .�5)      �� 	 � ��
 �#4d695063   �� 5+      	 � ��$
 40��6/   �� 5,      	 � ��
 �#4d695064   �� 5-      	 � ��$
 28(�61   �� 5.      	 � ��$
 Black"�63   50      �� 51      " ��6   .�54      �� 	 � ��

 �   �63   �� 55      	 � ��$

 auto��6/   �� 57      	 � ��$
 25(�61   �� 58      	 � ��$
 SemiBold"�63    5=      P� 5>       �@��
IsSelected$
 true��68   . �5?      �� 	 � ��
 �#D0E7D26;   5@      P� 5A       �@J�IsMouseOver$
 true��69   . �5C      �� 	 � ��
 �#B0D9B16;   5E      5G      5H      5I      5J      5K      