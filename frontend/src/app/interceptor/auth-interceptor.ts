import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { ToastService } from '../services/toast-service';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router)
  const toastServ = inject(ToastService)

  return next(req).pipe(
    catchError((error) => {
      if (error.status === 401) {
        router.navigate(['/authorization']).then(() => {
          toastServ.show('token expired', 'error')
        });
      }

      return throwError(() => error);
    })
  );

  return next(req);
};
