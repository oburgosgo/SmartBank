import { Link } from "react-router-dom";
import Login from "./Login";
import { FaGithub, FaLinkedinIn, FaTwitter } from "react-icons/fa"


export default function LoginPage() {
    return (
        <div className="flex min-h-screen items-center justify-center p-0">
            <div className="flex w-full max-w-4xl min-h-[500px] overflow-hidden rounded-xl shadow-sm">

                <div className="relative hidden w-1/2 bg-primary md:block rounded-l-xl">
                    <div className="absolute inset-0 z-0">
                        <img
                            src="/images/1.jpg?height=800&width=600"
                            alt="Mountain landscape"
                            className="object-cover opacity-50"
                        />
                    </div>
                    <div className="relative z-10 flex h-full flex-col justify-between p-6 lg:p-8 text-primary-foreground">
                        <Link to="/">
                            <img src="/images/logo-white.png" alt="Logo" className="h-16 w-auto" />
                            <h2 className="mt-6 text-xl font-semibold">Welcome to Smart Bank</h2>
                        </Link>
                        <div className="space-y-4">
                            <div className="flex space-x-4">
                                <Link
                                    to="#"
                                    className="rounded-full bg-primary-foreground/20 p-2 transition-colors hover:bg-primary-foreground/30"
                                >
                                    <FaGithub size={20} />
                                </Link>
                                <Link
                                    to="#"
                                    className="rounded-full bg-primary-foreground/20 p-2 transition-colors hover:bg-primary-foreground/30"
                                >
                                    <FaTwitter size={20} />
                                </Link>
                                <Link
                                    to="#"
                                    className="rounded-full bg-primary-foreground/20 p-2 transition-colors hover:bg-primary-foreground/30"
                                >
                                    <FaLinkedinIn size={20} />
                                </Link>
                            </div>
                            <div className="space-y-1 text-sm">
                                <Link to="#" className="block hover:underline">
                                    Have an issue with 2-factor authentication?
                                </Link>
                                <Link to="#" className="block hover:underline">
                                    Privacy Policy
                                </Link>
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
