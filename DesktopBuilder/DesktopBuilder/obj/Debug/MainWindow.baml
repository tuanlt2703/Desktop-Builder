   M S B A M L   `   `   `  ����I  EDesktopBuilder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:DesktopBuilder.ControlsDesktopBuilder.Controls  5   	       DesktopBuilder.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :Controls%clr-namespace:DesktopBuilder.Controls     5   	     � 
ResizeMode$  NoResize=�6d    � Title$ DesktopBuilder��5   	   $	��540��6    $	��785��6-   .��5      � .+�5   
   �� -   5         ��Name$ btnComponents��5      $��12,20,648,383q�6(   ��5	      �� 5
       �� 
TargetType" ��6"   .R�5      � .+�5      �� 5      5      .��5      �� .+�5      �� $��/Image/Component.png��6   $��Center=�66   $��Center=�6S   $	��112��6n   $	��3,0q�6{   5      5      �� 5   
   -   5         ��Name$ recComponentSelected��5      $y�Hidden=�62   $
��Left=�6F   $	��111��6a   $��	11,15,0,0q�6n   ���#00B0F0$��2��6�   $	��Top=�6�   $	��117��6�   � 5   
   -   5         �Name$ gridComponents��5      $
��Left=�6'   $	��Top=�6B   $	��641��6Z   $	��510��6f   $��	138,0,0,0q�6s   $y�Hidden=�6�   .+�5      ,   &DesktopBuilder.Controls.ComponentsList  -   5          Name$ 	compoList��5   &   $
��Left=�69   $	��Top=�6T   5      �� 5   
   -   5        $ 
btnAdvisor��5      $��10,196,650,223q�6%   ��5      �� 5      " ��6"   .R�5      � .+�5      �� 5      5       .��5"      �� .+�5#      �� $��/Image/Advisor.png��6   $��Center=�64   $��Center=�6Q   $	��104��6l   5$      5%      �� 5&   
   -   5        $ recAdvisorSelected��5&      $y�Hidden=�60   $
��Left=�6D   $	��111��6_   $��	7,186,0,0q�6l   ���#2F5E73$��2��6�   $	��Top=�6�   $	��117��6�   � 5'   
   -   5        $ gridAdvisor��5'      $
��Left=�6$   $	��Top=�6?   $	��641��6W   $	��510��6c   $��	138,0,0,0q�6p   $y�Hidden=�6�   .+�5(      ,   &DesktopBuilder.Controls.DesktopAdvisor  -   5          Name$ Advisor��5(   &   $
��Left=�67   $	��Top=�6R   5)      �� 5,   
   -	   5        $ 	btnCustom��5,      $��9,363,651,32q�6$   ��5-      �� 5.      " ��6"   .R�5/      � .+�50      �� 51      52      .��54      �� .+�55      �� $��/Image/Custom.png��6   $��Center=�63   $��Center=�6P   $	��112��6k   56      57      �� 58   
   -
   5        $ recCustomSelected��58      $y�Hidden=�6/   $
��Left=�6C   $	��123��6^   $��	8,356,0,0q�6k   ���#009688$��2��6�   $	��Top=�6�   $	��117��6�   � 59   
   -   5        $ 
gridCustom��59      $
��Left=�6#   $	��Top=�6>   $	��641��6V   $	��510��6b   $��	138,0,0,0q�6o   $y�Hidden=�6�   .+�5:      +   %DesktopBuilder.Controls.Customization  -   5          Name$ Custom��5:   %   $
��Left=�65   $	��Top=�6P   5;      �� 5=   
   $
��Left=�6   $	��Top=�6/   ���#00B0F0$��5��6X   $	��511��6l   $��4��6y   $��	134,0,0,0q�6�   �� 5?   
   -   5        $ OpenDtb��5?      $��Database��6"   $
��Left=�65   $��	8,479,0,0q�6P   $	��Top=�6c   6{   � 5@   
   -   5        $ gridDtb��5@      $
��Left=�6    $	��Top=�6;   $	��641��6S   $	��510��6_   $��	138,0,0,0q�6l   $y�Hidden=�6   .+�5A      *   $DesktopBuilder.Controls.DatabaseView  $
��Left=�6$   $	��Top=�6?   $	��509��6W   5B      5E      5F      