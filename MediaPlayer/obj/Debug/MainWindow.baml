   M S B A M L   `   `   `  ����F  BMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MediaPlayerMediaPlayer  5   	       MediaPlayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MediaPlayer     5   	   -   5          � Title$  MediaPlayer��5	   	   $	��250��6   $	��400��6-   $	��550��6<   $	��950��6I    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ local:CustomCommands.Exit��5      5        5   
   -   5        $ local:CustomCommands.Play��5      5        5   
   -   5        $ local:CustomCommands.Stop��5      5        5   
   -   5        $  local:CustomCommands.Pause��5      5        5   
   -   5        $
 Open��5      5       � 	Resources 5!       �� 
TargetType   MediaButton �� Property �� Value*  $MediaPlayer.SecondsTimeSpanConverter  SecondsTimeSpanConverter!  MediaPlayer.VolumeConverter  VolumeConverter��%�   &	        &	 l     &	      �� 5"   
   " ��6   .�5#      ��  � ��$ 10q�6'   �� 5$       � ��$ 10q�6(   5%        5'   
   6)     5(   
   6    5)      .��5,      ]� 
�������.+�5.   
   o� -   5         o�Name$ MenuBar��5.      $	��Top=�6    .@�5/      m� $
��File��6   .@�50      m� $
��Open��6    m� Command$
 Open��6)   �� 51      m� 52      $
��Exit��6   $ local:CustomCommands.Exit��6)   53      54      � 56   
   -   5        	 �Name$	 	ToolsGrid��56      $��Bottom=�6"   
�������
 � RowDefinitions
 57      �� 58      $��60 �6    �� 59      $
��0.5* �6     � ColumnDefinitions 5;      �� 5<      $
��0.8* �6#   �� 5=      $
��0.8* �6#   �� 5>      $
��0.8* �6#   �� 5?      $��6* �6#   �� 5@      $
��0.7* �6#   �� 5A      $
��0.2* �6#   �� 5B      $
��0.7* �6#   �� 5C      $
��0.5* �6#   �� 5D      $
��0.5* �6#   .+�5G      �� -	   5         ��Name$ 
PlayButton��5G      #��[  6)   $��local:CustomCommands.Play��6g   $��0��6�   $��5q�6�   ��5H      �� 5I      $��images/PlayIcon.png��6   5K      �� 5L      -
   5        $ PauseButton��5L      #��[  6*   $ ��local:CustomCommands.Pause��6i   $��1��6�   ��5M      �� 5N      $��images/PauseIcon.png��6   5P      �� 5Q      -   5        $ 
StopButton��5Q      #��[  6)   $��local:CustomCommands.Stop��6g   $��2��6�   $��11q�6�   ��5R      �� 5S      $��images/StopIcon.png��6   5U      �� 5V      -   5         ��Name$ MediaSlider��5V      $��Center=�5W      $��10q�5X      $	��200��5Y      $��3��5Z      5]      �� 5_      -   5         ��Name$ WatchedTime��5_      $��4��6)   $��Center=�6�   $��Center=�6�   ��69   ��  �� ElementName$ MediaSlider�� �� Path$ Value� �� 	Converter# [ 6�   �� 5`      $��/��6   $��Center=�6    $��5��6;   �� 5a      -   5        $ TotalVideoTime��5a      $��6��6,   $��Center=�6�   $��Center=�6�   ��6<   �� $ MediaSlider��$ Maximum�# [ 6�   d� 5c      -   5         d�Name$ VolumeButton��5c      $��30��61    � Cursor$
 Hand��6=   $��0,0,10,0q�6K   $��7��6]   ��5d      �� 5e      $��images/VolumeIcon.png��6   5g      �� 5i      $
��Open��6   $��30��6$   $
 Hand��60   $��8��6>   $��0,0,10,0q�6N   ��5j      �� 5k      $��images/open_file.png��6   5m      �� 5p      $��1��6   $��4��6!   $
��Vol:��61   ��5q      �� 5r      " ��6   .�5s      ��  � y�$ 	Collapsed=�67    �� Triggers 5t      �� 5u       �� Binding 6*   �� $ VolumeButton��$ 	IsChecked� �� Value True6g   .a�5v   "   ��  � y�$ Visible=�6?   5w      5y      5{      �� 5}      $��1��6   $��5��6"   $��4��62   $��0,0,10,0q�6F    � Maximum$ 1Q�6�    � Value 6X   �� $ PlayedMedia��$ Volume� � ToolTip 5~      �� $ PlayedMedia��$ Volume�# [ ��5      �� 5�      " ��6   .�5�      ��  � y�$ 	Collapsed=�67    5�      �� 5�       6*   �� $ VolumeButton��$ 	IsChecked� True6g   .a�5�   "   ��  � y�$ Visible=�6?   5�      5�      5�      5�      �� 5�   
   $��5q�6   
���   �._�5�      r� -   5         r�Name$ PlayedMedia��5�       r� LoadedBehavior$ Manual=�5�      5�      5�      5�      5�      