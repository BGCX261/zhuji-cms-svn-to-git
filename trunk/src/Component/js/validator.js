function ValidatorControl_Validate_KeyUp(ctrl,regex)
{
	ctrl.value = ctrl.value.replace(regex,'')
}
function ValidatorControl_Validate_BeforePaste(ctrl,regex)
{
	ctrl.value = ctrl.value.replace(regex,'')
}