interface ILogin {
    email: string
    password: string
}

interface IRegister extends ILogin {
    userName: string
    contact: string
    confirmPassword: string
}

interface IPasswordReset extends ILogin {}
interface IUser {
    id: string
    email: string
    userName: string
    contact: string
}

export type { ILogin, IRegister, IUser, IPasswordReset }
