enum RouterEnum {
    HOME = 'Home',
    LOGIN = 'Login',
    SIGNUP = 'SignUp',
    VERIFY_EMAIL = 'VerifyEmail',
    VERIFY_OTP = 'VerifyOtp',
    PASSWORD_RESET = 'PasswordReset',
    PROJECT = 'Projects',
    SHARED = 'Shared',
    PROJECT_BY_TAG = 'ProjectByTag',
    KEEP_BY_TAG = 'KeepByTag',
    KEEP = 'Keeps',
    ITEM = 'Items',
    PAGE_NOT_FOUND = 'PAGE_NOT_FOUND'
}

enum ItemType {
    TICKET,
    PR
}

const enum StatusType {
    SUCCESS,
    ALREADY_EXISTS,
    NOT_FOUND,
    NOT_AUTHORISED,
    NOT_VALID,
    INTERNAL_SERVER_ERROR
}

enum TagTypeEnum {
    PROJECT,
    KEEP
}

enum NoRecord {
    Empty,
    NotFound
}
enum Colors {
    SUCCESS = 'success',
    INFO = 'info',
    WARNING = 'warning',
    DANGER = 'danger',
    PRIMARY = 'primary',
    SECONDARY = 'secondary'
}
export { RouterEnum, ItemType, StatusType, TagTypeEnum, NoRecord, Colors }
