const requiredRule = (val: string) => val.trim() == "" ? "This field is required!" : true
const emailRules = (value: any) => /.+@.+\..+/.test(value) ? true : 'E-mail must be valid.'
const passwordRule = (val: string) => val.length < 8 ? "At least 8 characters!" : true
const contactRules = (value: string) => /^[6-9]{1}[0-9]{9}$/.test(value) || value == '' ? true : 'Contact number must be valid'
const userNameRules = (value: string) => /^[a-zA-Z ]{2,30}$/.test(value) ? true : 'Username must be valid.'
 const otpRules=(value:string)=>/^[0-9]{6}$/.test(value) ||value==''?true:'OTP must be valid'
 const numberRules=(value:string)=>/^[0-9]{5}$/.test(value)||value==''?true:'Number must be valid'
export {
    requiredRule,
    emailRules,
    passwordRule,
    contactRules,
    userNameRules,
    otpRules,
    numberRules
}
