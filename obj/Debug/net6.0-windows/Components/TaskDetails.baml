   M S B A M L   `   `   `  ����G  CTasksProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TasksProject.ComponentsTasksProject.Components  5      9!clr-namespace:TasksProject.ModelsTasksProject.Models  6B   )    #TasksProject.Components.TaskDetails   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:TasksProject.Components     5      4models!clr-namespace:TasksProject.Models     6B     � 	Resources  5	      2   ,TasksProject.Models.BooleanToStringConverter   BooleanToStringConverter��%   &	          5
   
   6*   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6I   .+�5      �� $
��auto��6;   $��40��6H   $��20(�6T   $
��Bold"�6b   
���   �$��1q�5   )   ��5      �� *MarkAsDoneCommand+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value �#94949467    �� Triggers 5      �� 5       �� Binding 6*   �� *IsDone+ �� Value True6E   .a�5   "   ��  � ��$ Unmark as done��6<   5      �� 5       6*   �� *IsDone+	 False6E   .a�5   "   ��  � ��$ Mark as done��6<   5      �� 5       6*   �� *IsDone+ 6E   Z� .a�5    "   ��  � ��$ Select Task��6<   5!      5#      5&      �� 5'      $��Delete task��6     MainButtonTheme#��[ 6Q   $��30 0 0 0q�6z   ��6+   �� *DeleteTaskCommand+6z   5)      �� 5*   
   $��1��6   .+�5,      �� $
��auto��6/   $��50(�6<   $
��Bold"�6J   $��Center=�6\   $��0 10 0 0q�6y   $
��Wrap=�6�   ��6   �� *Title+6�   �� 5-      $
��auto��65   $��20(�6B   $��Center=�6P   $��
20 20 20 0q�6m   $
��Wrap=�6�   ��6   �� *Description+6�   �� 5.      $��25(�6f   $��0 30 0 0q�6t   $��Center=�6�   ��6   �� *IsDone+	 �� 	Converter#	 [  ��5/      �� 50      " ��6    51      P� 52      
 P� Property
 � �� P� Value$ 
In Process��66   . �53   "   ��  � ��
 �  ��6?   54      P� 55      
 � ��$ Finished��66   . �56   "   ��  � ��
 � � �6?   57      59      5;      5<      5?      5@      