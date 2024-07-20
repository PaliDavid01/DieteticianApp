import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-localization',
  templateUrl: './localization.component.html',
  styleUrls: ['./localization.component.css'],
})
export class LocalizationComponent implements OnInit {
  isDarkMode: boolean;

  languages: Language[] = [];
  selectedLanguage: Language | any;
  selectedCountry: string | undefined;

  constructor() {}

  ngOnInit(): void {
    this.languages = [
      {
        name: 'English',
        code: 'en',
        svg: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAFOElEQVR4nO2Z+08cVRTHx9dvVmN/0P4PmqiBaXfAzkDFiNLiDHUbVNTEH7BpGm3RRpO2QLSxVBsTK0l/0DStWkiaasDOAKXALrAib1wo4WF5OsOyy8I+2F3Y3Zk95g5LXOgszLLDQg3f5P7Azr3nns/lPs65F8N2tKMdaSKKufUcAJwEgOsCgbfxOnycJ3CvXHT4OPoNfUN1UF1sO+jAocpnSJotJGn2LsVwsCyBwBXLslBdkub6SJo9TenZPQl3PCW7YhfJsJ9RDOtCziyXWAAiipeiuZIM/Z0nE+J8GsNmkQw3s8qJeABALjRrRbY3zfGk/M7HSJr7hmLYkKID8QIwqLAhiua+Q31p6rxef+MRkubKo3esFQC3tD4YrkIzCOQ8RbPX1+tUSwBKhmBvor7jBvD7pW9vG3lDhr7an0iAl49UL9Y0TBbG5TwAHFnu1B8QR86UdHYkAuBMSYc5EJBG5cqLi29u1PndAGCFVbLafO1H8uunNgPg8Af11pEJlwkAQiBJIdfVKyYhdd/QSFJS7Fus/aNjRUGLxQIKkiRw3vh91JCWUyVqAZDOVEm/3Py7SZLAhb4H7t0bs7z2SvdyO16XfD4m5yd1ut08gXtQGOA494URgsGgEohvQRw4WdjaFw/AibOtg15vYFAeGJ/Pay84YRAIPBDZbupgJgpD1J/YPIGfXWHgADng7+rsV4JA/Q4MO+uy8mpnYwHIyrvt7OmzNwKAKA9GfV2rQBKjq9rMuS6XNqHpBADqFjQAPBTk+T+nmTdMkcZ4Apes7+e1iQ6HS3laSTYAkOfvOgChH8uGm0VJmkF/iDabZTpX37iqr5A17+0WcdY+F9HFmFqAFwDAg1p4KitahNR9/ArjqXut7mtXWyG6etYA6AGAv+Raoii5Si818ATuXlGPTBn3GRrMUWw/rwbgEwBAi7cLYtcCABjWAAgAQHO4XqxCg3ZMDUBZRKN2AJhU2UE3AIyoWQMAMAEAHSrtTob9QCpbF4DXJXdEc2CrC6/D21UAyNnT9gQgktdfyGjv374AuPdBB/CoAEge28ZTaFTNGmjfakeF6KVtXYDw1QeEDzMjACjGQWspmgMbVBAAUMjhVrWNAkBBeN8VNtrjGgDjG7UJS4frh2oAXlQeh2DAeeH8HbSQIp2aSieH/N1dgypPYvl7tJPYU1nxh2Lo8tO1dtWhRBhiKRsKa9Hc0yek7+9ftSN4HV+dawZRlKNJ2+xCR/iEXXcK5R03TthnFzqVIKT5effM0Xwjr0sWI9tO65kqFGiqBSiWjfl88/aPj9fdZ+xQVkeQ/4dHdURRmrr0Q79xI/lAyffm9mBQVJyq/r7ewamMtLsR7T9X5XwYYI+Hu9UivKQTVv8758vLWpYnVafZ3pD5Vs18PAnNq7k1XoNJQJuF/z4KFLFeLm3iCdxmIYinsVgkEPjXEdMlNP1Orkmcm5OTFpc70Jv/qWlYy5z46CnTkNsT7FWcVk7nRSxWzaSk7BJ0uCDsl+Pz7nAu7PiVG2tEOexmJPVpOWzoSvlQiyhJkYkMSpSewjaiuYsXsiX/4iLKooZGnMbs92rtibhWOfhurSOcbkroageLRzb7QklB8X+Je6IutiiGg1NfthVjmtyLMlxZogFIhvsZKyp6GNPsZprhKhIGQHO/UZThUUxLIYMUwxVTNCdt8vV6iWYjryT0CEHRrE1rAJLmLGRO1etYIkTpDY9r9cREMqwHjfrezKonsC165DuNHuxiBqBZMxoEZAN70J5Z0w9XP7vV/u5oR/8X/Qsqblqc0YX1FgAAAABJRU5ErkJggg==',
      },
      {
        name: 'Hungarian',
        code: 'hu',
        svg: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAACXBIWXMAAAsTAAALEwEAmpwYAAACj0lEQVR4nO2YTU/UQBzGn8UET+LbQQ/6BbgYiNmZaGc5yAE9inwBNXQ4oIlGSXwJHIkIylVlJsZoEDQavwch8a4oYT24ZbtFOcCBv2lBIuqGdtvtdMM+yZP00J39PX3mpSnQVFNNxRb1YR8JdFIB10lglgTmycIiCawG3ryeJ4EZsnCNCujwfwPToi4cJwtDZGGBBCiiiyQwSgIn0wfPo40sPCKB9RrA//Y6CUz4Y6YDb+ESWfiWAPhOb47ZWz9wIEcCIySwkTi82OFJAlqShe/BfhL4UGdw+qON99SO1mTggZZg90gLXmyHmE6kCbLwOHV4se3xePAFXDAIT4HP4nxt8N04uHUAmQ0gsERdOBQ9gL83m4enrfXwMBo8xxGy8CNDAX7SORyN8vTvG4cW/4S4Gw6eKFdyvS+O61GWXCp7Cz7brgFKlcpp07BOFX933c7dA7grt02DOtVacL2buwcoe29MgzrVp9FsiAYqH02DOtVc9ubDNFDObgMVJ0SAynqGA6zthQDecmNPIbfxF/FsdhvwZkI04N0yDepU8bLr3Wj0V4kOhJFT9j417MucL6nYPak5ZcqK30FYDby0DkvNVoxD699mKz5T6ABBC5qPmwfngW3FHiCqBl/k22zNF03DS8W+Xn525gBq0cAU75aKb5gM0K95D+JIajZhMMAYYouQk4o9Tx+evRoeTugjb99Me6ut2LsUA7z1/xOJipCzNRup95qwFZ9M7Mn/T1KzXluzYuLgmhX7FbuINORva8E5ofhabHgVjDFW81YZR1eesmMDig1JxT9HB2dLtuajV5/kT8C0/DlrT+VP9Ws+KBV7LTWb8w8gqflq4OCazUnNp/17/HvrOs+bamoP6RfeUqwZgRloRAAAAABJRU5ErkJggg==',
      },
    ];
    if (localStorage.getItem('lang')) {
      this.selectedLanguage = this.languages.find(
        (t) => t.code == (localStorage.getItem('lang') as string)
      );
    }
    let mode = localStorage.getItem('theme');
    let themeLink = document.getElementById('app-theme') as HTMLLinkElement;
    if (mode) {
      if (mode == 'dark') {
        this.isDarkMode = true;
        themeLink.href = 'lara-dark-blue.css';
      } else {
        this.isDarkMode = false;
        themeLink.href = 'lara-light-blue.css';
      }
    } else {
      const darkModeOn =
        window.matchMedia &&
        window.matchMedia('(prefers-color-scheme: dark)').matches;
      if (darkModeOn) {
        this.isDarkMode = true;
        themeLink.href = 'lara-dark-blue.css';
      } else {
        this.isDarkMode = false;
        themeLink.href = 'lara-light-blue.css';
      }
    }
  }

  initTheme() {
    const darkModeOn =
      window.matchMedia &&
      window.matchMedia('(prefers-color-scheme: dark)').matches;
  }

  setLang() {
    localStorage.setItem('lang', this.selectedLanguage.code);
    window.location.reload();
  }
  toggleDarkMode() {
    let themeLink = document.getElementById('app-theme') as HTMLLinkElement;
    if (this.isDarkMode) {
      localStorage.setItem('theme', 'dark');
      themeLink.href = 'lara-dark-blue.css';
    } else {
      localStorage.setItem('theme', 'light');
      themeLink.href = 'lara-light-blue.css';
    }
  }
}
interface Language {
  code: string;
  name: string;
  svg: string;
}
