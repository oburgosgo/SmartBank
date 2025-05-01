import { Link } from "react-router-dom";
import Login from "./Login";

export default function LoginPage() {
    return (
        <div className="flex min-h-screen items-center justify-center p-0">
            <div className="flex w-full max-w-4xl min-h-[500px] overflow-hidden rounded-xl shadow-sm">
                {/* Left side - Primary background with mountain image */}
                <div className="relative hidden w-1/2 bg-primary md:block rounded-l-xl">
                    <div className="absolute inset-0 z-0">

                    </div>
                    <div className="relative z-10 flex h-full flex-col justify-between p-6 lg:p-8 text-primary-foreground">
                        <Link to="/">
                            <img src="/images/logo-white.png" alt="Logo" className="h-8 w-auto" />
                            <h2 className="mt-6 text-xl font-semibold">Welcome to enfix</h2>
                        </Link>
                        <div className="space-y-4">
                            <div className="flex space-x-4">

                            </div>
                            <div className="space-y-1 text-sm">

                            </div>
                        </div>
                    </div>
                </div>

                {/* Right side - White background with login form */}
                <div className="w-full md:w-1/2 flex flex-col">
                    <Login />
                </div>
            </div>
        </div>
    )
}
