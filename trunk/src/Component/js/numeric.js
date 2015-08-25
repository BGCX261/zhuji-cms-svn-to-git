function NumericControl_Validate_KeyPress(ctrl,dec,AllowNegative)
{	
	var i = ctrl.value.indexOf('.');
	var len = ctrl.value.length;
	var pos= getCursorPosition(ctrl);
	if(i>0)
	{
		if(len-i>dec && pos>i)
		{
			return false;
		}
	}
	//.·ûºÅÅÐ¶Ï
	if(event.keyCode==46)
	{
		if(i<0 && dec > 0)
		{
			
			if (len-pos <= dec)
			{
				return true;
			}
		}
	}
	if (AllowNegative)
	{
		//-·ûºÅÅÐ¶Ï
		if(event.keyCode==45)
		{
			if(ctrl.value.indexOf('-')<0)
			{
				if (pos == 0)
				{
					return true;
				}
			}	
		}
	}
	//Êý×ÖÅÐ¶Ï
	if(event.keyCode>=48 && event.keyCode<=57)
	{		
		return true;
	}
	return false;
}
function NumericControl_Validate_Paste(ctrl)
{
	return !clipboardData.getData('text').match(/\D/);
}
function NumericControl_Validate_DragEnter(ctrl)
{
	return false;
}
function getCursorPosition(txt)
{
     if(document.selection) // IE

     {
         var oSel = document.selection.createRange();

         oSel.moveStart('character', -txt.value.length);

         return oSel.text.length;

     }

     else(txt.selectionStart) // Firefox etc.

         return txt.selectionStart;
}