   M S B A M L   `   `   `  ����J  FSystemInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:SystemInventory.ProductsFilesSystemInventory.ProductsFiles  5   	   /    )SystemInventory.ProductsFiles.EditProduct   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:SystemInventory.ProductsFiles     5   	     � Title$  EditProduct��5   	   $	��450��6   $	��800��6*   .��5	      � .+�5
   
   �� $!��Edit a Product in Inventory��6   $��Center=�66   $��0,10,0,0q�6S   $	��Top=�6e   $
��Bold"�6}   $��18(�6�   �� 5   
   -   5         ��Name$ 
Product_ID��5      $
��Left=�6&   $��22��6A   $��
121,91,0,0q�6M   $�� ��6a    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $	��149��6�   4  .System.Windows.Automation.AutomationProperties   HelpText$ Part ID��6�    �� 
IsReadOnly$
 True��6�   �� 5   
   -   5        $ Product_Name��5      $
��Left=�6(   $��22��6C   $��121,134,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��149��6�   $ 	Part Name��6�   �� 5   
   -   5        $ 	Inventory��5      $
��Left=�6%   $��22��6@   $��120,178,0,0q�6L   $�� ��6a   $
 Wrap=�6i   $	��Top=�6}   $	��149��6�   �� 5   
   -   5        $ Price��5      $
��Left=�6!   $��22��6<   $��121,217,0,0q�6H   $�� ��6]   $
 Wrap=�6e   $	��Top=�6y   $	��149��6�   �� 5   
   -   5        $	 Max��5      $
��Left=�6   $��22��6:   $��120,264,0,0q�6F   $�� ��6[   $
 Wrap=�6c   $	��Top=�6w   $	��149��6�   �� 5   
   -   5        $	 Min��5      $
��Left=�6   $��22��6:   $��119,304,0,0q�6F   $�� ��6[   $
 Wrap=�6c   $	��Top=�6w   $	��149��6�   �� 5   
   -   5         ��Name$ BtnSaveProduct��5      $
��Save��6)   $
��Left=�68   $��29��6S   $��159,383,0,0q�6_   $	��Top=�6t   $	��186��6�   6�   �� 5   
   -   5        $ CancelSaveButton��5      $��Cancel��6+   $
��Left=�6<   $��29��6W   $��387,383,0,0q�6c   $	��Top=�6x   $	��186��6�   6�   �� 5   
   $��
Product ID��6   $
��Left=�6%   $��23��6@   $��	15,90,0,0q�6L   $	��Top=�6_   $��66��6w      IsColumnHeader$
 True��6�   �� 5   
   $��Product Name��6   $
��Left=�6'   $��23��6B   $��
14,134,0,0q�6N   $	��Top=�6b   $	��102��6z   $
 True��6�   �� 5   
   $��	Inventory��6   $
��Left=�6$   $��35��6?   $��
15,177,0,0q�6K   $	��Top=�6_   $��66��6w   $
 True��6�   �� 5   
   $��Price��6   $
��Left=�6    $��23��6;   $��
14,217,0,0q�6G   $	��Top=�6[   $��79��6s   $
 True��6~   �� 5   
   $	��Max��6   $
��Left=�6   $��23��69   $��
15,264,0,0q�6E   $	��Top=�6Y   $��66��6q   $
 True��6|   �� 5   
   $	��Min��6   $
��Left=�6   $��33��69   $��
15,304,0,0q�6E   $	��Top=�6Y   $��66��6q   $
 True��6|   &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ DgProdParts��5         CanUserAddRows$ False��6(   $
��Left=�6?   $��95��6Z   $��
416,86,0,0q�6f   $	��Top=�6z   $	��355��6�   6�     5   
   -
   5        $ DgFilteredParts��5      $ False��6,   	 J� 	AllowDrop$
	 True��6C   $
��Left=�6T   $��95��6o   $��416,236,0,0q�6{   $	��Top=�6�   $	��355��6�   6�   �� 5   
   -   5        $ BtnSearchParts��5      $��Search��6)   $
��Left=�6:   $��
523,45,0,0q�6U   $	��Top=�6i   $��80��6�   6�   �� 5   
   -   5        $ SearchPartBox��5      $
��Left=�6)   $��30��6D   $��
621,45,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��150��6�   �� 5   
   -   5        $ BtnAddPartToProduct��5      $	��Add��6.   $
��Left=�6<   $��696,197,0,0q�6W   $	��Top=�6l   $��74��6�   6�   �� 5   
   -   5        $ BtnDeletePartFromProduct��5      $��Delete��63   $
��Left=�6D   $��695,353,0,0q�6_   $	��Top=�6t   $��75��6�   6�   
 � 	Resources
 5   
   *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5       "  6    5!      P� 5"       �@ 
IsSelected$
 True��6A   . �5#      ��  � ��
 ����67   5$      5&      5'      5(      5)      