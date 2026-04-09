export interface ContactModel {
    id: number
    email: string
    location: string
    phoneNumber: string
    githubLink: string
    linkedinLink: string
}

export interface UserProfileModel {
    id: number
    fullName: string
    contact: ContactModel
}