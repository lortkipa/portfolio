export interface EmailJSModel {
    id: number
    serviceId: string
    templateId: string
    publicKey: string
}

export interface ContactModel {
    id: number
    emailJS: EmailJSModel
    email: string
    location: string
    phoneNumber: string
    githubLink: string
    linkedinLink: string
}

export interface AboutModel {
    id: number
    fullName: string
    jobTitle: string
    bio: string
    statusBadge: string
    funBadge: string
}

export interface UserProfileModel {
    id: number
    contact: ContactModel
    about: AboutModel
}

export interface LoginUserModel {
    email: string
    password: string
}