   M S B A M L   `   `   `  ����J  FSystemInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SystemInventorySystemInventory  5   	        SystemInventory.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:SystemInventory     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ Supply_Inventory��5
      $��Supply Inventory��6*   $��Center=�6E   $��0,23,0,0q�6b   $	��Top=�6t   $��33��6�   $	��155��6�   $
��Bold"�6�   $��18(�6�   �� 5   
   -   5         ��Name$ BtnSearchPart1��5      $��Search��6N   $
��Left=�6_   $��
141,68,0,0q�6z   $	��Top=�6�   $��80��6�   {�6)   �� *BtnSearchPart1+6�   �� 5   
   -   5         ��Name$ SearchPartBox��5      $
��Left=�6@   $��30��6[   $��
239,68,0,0q�6g    �� TextWrapping$
 Wrap=�6{   $	��Top=�6�   $	��150��6�   {�6)   �� 6�   �� 5   
   -   5        $ BtnSearchProduct��5      $��Search��6+   $
��Left=�6<   $��
470,68,0,0q�6W   $	��Top=�6k   $��80��6�   6�   �� 5   
   -   5        $ SearchProductBox��5      $
��Left=�6,   $��30��6G   $��
568,68,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��150��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DgParts��5      $
��Left=�6$   $	��178��6?   $��
51,133,0,0q�6L   $	��Top=�6`   $	��315��6x   6�     5   
   -   5        $ 
DgProducts��5      $
��Left=�6'   $	��178��6B   $��441,133,0,0q�6O   $	��Top=�6d   $	��315��6|   6�   �� 5   
   $��Parts��6   $
��Left=�6    $��	51,85,0,0q�6;   $	��Top=�6N   $��56��6f   �� 5   
   $��Products��6   $
��Left=�6#   $��
441,87,0,0q�6>   $	��Top=�6R   �� 5   
   -   5        $ 
BtnAddPart��5      $	��Add��6%   $
��Left=�63   $��122,316,0,0q�6N   $	��Top=�6c   $��74��6{   6�   �� 5   
   -	   5        $ BtnModifyPart��5      $��Modify��6(   $
��Left=�69   $��206,316,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5   
   -
   5        $ BtnDeletePart��5      $��Delete��6(   $
��Left=�69   $��291,316,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5   
   -   5        $ BtnAddProduct��5      $	��Add��6(   $
��Left=�66   $��519,316,0,0q�6Q   $	��Top=�6f   $��74��6~   6�   �� 5   
   -   5        $ BtnModifyProduct��5      $��Modify��6+   $
��Left=�6<   $��599,316,0,0q�6W   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $ BtnDeleteProduct��5      $��Delete��6+   $
��Left=�6<   $��681,315,0,0q�6W   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $ BtnExitProgram��5      $
��Exit��6)   $
��Left=�68   $��681,364,0,0q�6S   $	��Top=�6h   $��75��6�   6�    � 	Resources 5   
   *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers	 P� Property
 P� Value �� Property �� Value��%�   '        �� 5      "  6    5      P� 5      	 �@ 
IsSelected$

 True��6A   . �5      ��  � ��
 ����67   5      5!      5"      5$      5%      