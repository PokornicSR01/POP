   M S B A M L   `   `   `  ����L  HSR01-2021-POP2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SR01_2021_POP2022.WindowsSR01_2021_POP2022.Windows  5   	   2    ,SR01_2021_POP2022.Windows.ReservisiCasWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SR01_2021_POP2022.Windows     5   	     � Title$  ReservisiCasWindow��5   	   $	��200��6$   $	��400��61   
��� ���.��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $	��250 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��
lblStudent��5      $��Student:��6"   $��0��65   $��2��6E   6T   �� 5   
   -   5        $��
cmbStudent��5      $��1��6%   $��2��65   $��0,0,0,10q�6B    �� Text 6T   ��  �� Path$ Student� �� ValidatesOnDataErrors$
 True��5      �� 5   
   -   5        $��btnOdustani��5      $��Odustani��6$   $��1��67   $��3��6G   $	��100��6T   $��
10,0,140,0q�6z   $��3��6�   �� 5   
   -   5        $��
btnSacuvaj��5      $��Sacuvaj��6#   $��1��65   $	��100��6E   $��3��6Q   $��
140,0,10,0q�6w   $��3��6�   5      5      