import { Injectable } from '@angular/core';
import { EmailJSModel } from '../models/user';
import emailjs, { type EmailJSResponseStatus } from '@emailjs/browser'

@Injectable({
  providedIn: 'root',
})
export class EmailjsService {
  sendEmail(fullName: string, email: string, subject: string, message: string, data: EmailJSModel) {
    if (data.publicKey != null && data.templateId != null && data.serviceId != null) {
      return emailjs.send(data.serviceId, data.templateId, {
        fullName: fullName,
        email: email,
        subject: subject,
        message: message
      }, { publicKey: data.publicKey }
      )
    }

    return true;
  }
}
