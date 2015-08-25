function NiceForm_Focus(ctl)
{
	ctl.className+=" nffocus";
}
function NiceForm_FocusOut(ctl)
{
	ctl.className=ctl.className.replace(new RegExp(" nffocus\\b"), "");
}
function NiceGrid_MouseOver(ctl)
{
	ctl.className+=" nfgriditemover";
}
function NiceGrid_MouseOut(ctl)
{
	ctl.className=ctl.className.replace(new RegExp(" nfgriditemover\\b"), "");
}
function NiceGrid_MouseDown(ctl)
{
	ctl.className+=" nfgriditemdown";
}