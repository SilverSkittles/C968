   M S B A M L   `   `   `  ����J  FSystemInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SystemInventory.PartsFilesSystemInventory.PartsFiles  5   	   (    "SystemInventory.PartsFiles.AddPart   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:SystemInventory.PartsFiles     5   	     � Title$  AddPart��5   	   $	��450��6   $	��800��6&   .��5	      � .+�5
   
   �� $��Add a Part to Inventory��6   $��Center=�62   $��0,10,0,0q�6O   $	��Top=�6a   $
��Bold"�6y   $��18(�6�   	� 5   
   -   5         	�Name$ BtnInHouseRadio��5      $��In-house��6/   $
��Left=�6B   $��
171,71,0,0q�6]   $	��Top=�6q   6�   	� 5   
   -   5        $ BtnOutSourcedRadio��5      $��
Outsourced��62   $
��Left=�6G   $��
328,71,0,0q�6b   $	��Top=�6v   6�   �� 5   
   -   5         ��Name$ Part_ID��5      $
��Left=�6#   $��22��6>   $��
106,91,0,0q�6J   $�� ��6^    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��149��6�   4  .System.Windows.Automation.AutomationProperties   Name$ Part_ID��6�    �� 
IsReadOnly$
 True��6�   �� 5   
   -   5        $ 	Part_Name��5      $
��Left=�6%   $��22��6@   $��107,134,0,0q�6L   $�� ��6a   $
 Wrap=�6i   $	��Top=�6}   $	��149��6�      HelpText$ 	Part Name��6�   �� 5   
   -   5        $ 	Inventory��5      $
��Left=�6%   $��22��6@   $��107,178,0,0q�6L   $�� ��6a   $
 Wrap=�6i   $	��Top=�6}   $	��149��6�   �� 5   
   -   5        $ Price��5      $
��Left=�6!   $��22��6<   $��107,217,0,0q�6H   $�� ��6]   $
 Wrap=�6e   $	��Top=�6y   $	��149��6�   �� 5   
   -   5        $	 Max��5      $
��Left=�6   $��22��6:   $��107,264,0,0q�6F   $�� ��6[   $
 Wrap=�6c   $	��Top=�6w   $	��149��6�   �� 5   
   -   5        $	 Min��5      $
��Left=�6   $��22��6:   $��343,264,0,0q�6F   $�� ��6[   $
 Wrap=�6c   $	��Top=�6w   $	��149��6�   �� 5   
   -	   5        $ 
Machine_ID��5      $
��Left=�6&   $��22��6A   $��107,308,0,0q�6M   $�� ��6b   $
 Wrap=�6j   $	��Top=�6~   $	��149��6�   �� 5   
   -
   5         ��Name$ addSaveButton��5      $	��Add��6(   $
��Left=�66   $��29��6Q   $��159,383,0,0q�6]   $	��Top=�6r   $	��186��6�   6�   �� 5   
   -   5        $ cancelSaveButon��5      $��Cancel��6*   $
��Left=�6;   $��29��6V   $��387,383,0,0q�6b   $	��Top=�6w   $	��186��6�   6�   �� 5   
   $��Part ID��6   $
��Left=�6"   $��23��6=   $��	15,90,0,0q�6I   $	��Top=�6\   $��66��6t      IsColumnHeader$
 True��6   �� 5   
   $��	Part Name��6   $
��Left=�6$   $��23��6?   $��
14,134,0,0q�6K   $	��Top=�6_   $��66��6w   $
 True��6�   �� 5   
   $��	Inventory��6   $
��Left=�6$   $��35��6?   $��
15,177,0,0q�6K   $	��Top=�6_   $��66��6w   $
 True��6�   �� 5   
   $��Price��6   $
��Left=�6    $��23��6;   $��
14,217,0,0q�6G   $	��Top=�6[   $��79��6s   $
 True��6~   �� 5   
   $	��Max��6   $
��Left=�6   $��23��69   $��
15,264,0,0q�6E   $	��Top=�6Y   $��66��6q   $
 True��6|   �� 5   
   $	��Min��6   $
��Left=�6   $��22��69   $��282,263,0,0q�6E   $	��Top=�6Z   $��66��6r   $
 True��6}   �� 5   
   -   5        	 ��Name$	 machineIdLabel��5      $
��Left=�6,   $��
15,314,0,0q�6G   $��
Machine ID��6[   $
��Wrap=�6m   $	��Top=�6�   $
��auto��6�   5      5      