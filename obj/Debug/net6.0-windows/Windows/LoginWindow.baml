   M S B A M L   `   `   `  ����L  HSR01-2021-POP2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SR01_2021_POP2022.WindowsSR01_2021_POP2022.Windows  5   	   +    %SR01_2021_POP2022.Windows.LoginWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SR01_2021_POP2022.Windows     5   	     � Title$  LoginWindow��5   	   $	��150��6   $	��350��6*   
��� ���.��5	      � $��0,0,3,0q�6    � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $	��250 �6   �� 5      $
��auto �6   �� 5      $	��300 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��1��6   $��0��6    .��6-   Podaci o korisniku:6B   �� 5   
   $��1��6   .��6   	E-mail:6&   �� 5   
   -   5        $��txtEmail��5   A   $��1��6   $��1��6   $��0,0,0,10q�6/   6A   �� 5   
   $��2��6   .��6   
Lozinka:6'   G� 5   
   -   5        $��
txtLozinka��5   E   $��2��6   $��1��6#   $��0,0,0,10q�63   6E   �� 5   
   -   5        $��	btnCancel��5      $��3��6"   $��2��6/   $��
52,0,151,0q�6C   $��11��6W   .��6�   Cancel6�   �� 5    
   -   5        $��btnLogin��5       $��3��6!   $��1��6.   $��	151,0,0,0q�6>   $��11��6Q   .��6z   Login6�   5!      5"      