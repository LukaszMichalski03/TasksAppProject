   M S B A M L   `   `   `  ����G  CTasksProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TasksProject.ComponentsTasksProject.Components  5      *    $TasksProject.Components.UsersListing   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:TasksProject.Components     5      .��5
      ��   �� SelectionMode$  Single=�5      ��5
      �� *UsersListingItemViewModels+ �� SelectedItem 5      �� *" SelectedUserListingItemViewModel+ �� Mode$ TwoWay=� �� View 5   
   �� 5      .P�5      ��  �� CellTemplate 5      �� 5      .R�5      �� $��Stretch=�6B   ��6(   �� *
Username+6B   5      5      5       � 	Resources 5   
    �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Triggers P� Property P� Value��%  '��       '�� �     '�� u    �� 5      " ��6   .�5       ��  � �� 5!      �� 5"      "	 ��6*   .R�5#      � ${�False��6#   5$      5&      5'      �� 5)      " ��6   .�5+      ��  � ��
 �   �6/   �� 5,       � ��$
 auto��6+   �� 5.       � ��$ 25(�6-   �� 5/       � ��$
 Bold"�6/   �� 50       � ��$ Stretch=�68   �� 51       � ��$ 0q�6+   
 53      P� 54       �@��
IsSelected$
 true��64   . �55      ��  � �� �#D0E7D267   56      P� 57       �@J�IsMouseOver$
 true��65   . �59      ��  � �� �#B0D9B167   5;      5=      �� 5?      " ��6   .�5@      ��  � �� �#6182646/   �� 5A       � ��$ 0q�64   5B      5C      5D      5E      