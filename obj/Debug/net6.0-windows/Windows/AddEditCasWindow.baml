   M S B A M L   `   `   `  ����L  HSR01-2021-POP2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SR01_2021_POP2022.WindowsSR01_2021_POP2022.Windows  5   	   0    *SR01_2021_POP2022.Windows.AddEditCasWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SR01_2021_POP2022.Windows     5   	     � Title$  AddEditCasWindow��5   	   $	��450��6"   $	��400��6/   
��� ���.��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $	��250 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��1��6   $��0��6    .��6-   Podaci o casu:6=   �� 5   
   $��2��6   .��6   Datum:6%   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��txtDatum��5   b   $��2��6   $��1��6"   $��0,0,0,10q�62      Text 6D   ��  �� Path$ Datum�6b   �� 5   
   $��3��6   .��6   Trajanje casa6,   �� 5   
   -   5        $��txtTrajanjeCasa��5   f   $��3��6   $��1��6   $��0,0,0,10q�6/   ��6A   �� $ TrajanjeCasa�6f   �� 5   
   $��4��6   .��6   Jezik6$   �� 5    
   -   5        $��txtJezik��5    _   $��4��6   $��1��6   $��0,0,0,10q�6/   ��6A   �� $ Jezik�6_   �� 5"   
   -   5        $��lblProfesor��5"      $��	Profesor:��6#   $��0��67   $��1��6G   6W   �� 5#   
   -   5        $��cmbProfesor��5#      $��1��6&   $��1��66   $��0,0,0,10q�6C    �� Text 6U   �� $ Profesor�5$      �� 5&   
   -   5        $��btnOdustani��5&      $��Odustani��6$   $��1��67   $��4��6G   $	��100��6T   $��10,32,140,-32q�6z   �� 5'   
   -   5        $��
btnSacuvaj��5'      $��Sacuvaj��6#   $��1��65   $	��100��6E   $��4��6Q   $��125,32,25,-32q�6w   5)      5*      