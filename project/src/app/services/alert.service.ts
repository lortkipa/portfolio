import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  text(message : string) {
    Swal.fire(message);
  }

  success(message : string) {
    Swal.fire({
      title: message,
      icon: "success",
      draggable: true
    });
  }

}
